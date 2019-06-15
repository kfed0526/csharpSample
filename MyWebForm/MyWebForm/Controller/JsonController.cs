using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Text;
using System.Net.Http.Headers;
using MyWebForm.Models;
using MyWebForm.Models.Service;

namespace MyWebForm.Controller
{
    public class JsonController : ApiController
    {
        private UserInfoService userInfoService = new UserInfoService();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        [HttpGet, HttpPost] // 讓此方法可同時接受 HTTP GET 和 POST 請求.
        public HttpResponseMessage getUser(string status)
        {
            StringBuilder sb = new StringBuilder();
            HttpContext context = HttpContext.Current;
            sb.Append("[");
            sb.Append("{");
            if (status == "list")
            {
                List<USER_INFO> userList = userInfoService.getUserInfoList();
                foreach (USER_INFO userInfo in userList)
                {
                    sb.Append(" userId :" + "\"" + userInfo.USER_ID + "\",");
                    sb.Append(" userName :" + "\"" + userInfo.USER_NAME + "\"");
                }
            }
            sb.Append("}");
            sb.Append("]");
            var result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
            return result;
        }
    }
}