using System;
using System.Web;

namespace TestWeb.Models
{
    public class _BaseModel
    {
        public DateTime CreateDate { get; set; } = DateTime.Now; //沒塞值預設給系統時間
        public string CreateUserID { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now; //沒塞值預設給系統時間
        public string UpdateUserID { get; set; }
    }
}
