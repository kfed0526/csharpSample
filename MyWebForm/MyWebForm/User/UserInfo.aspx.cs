using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebForm.Models;
using MyWebForm.Models.Service;
using MyWebForm.App_Code;

namespace MyWebForm.User
{
    public partial class UserInfo : System.Web.UI.Page
    {
        private UserInfoService userInfoService = new UserInfoService();
        private CommonTool commonTool = new CommonTool();
        private List<Panel> panelList = new List<Panel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            panelList.Add(Panel_Query);
            panelList.Add(Panel_Edit);
            if (!Page.IsPostBack)
            {
                ucPage.Index = 1;
                BindData();
            }
        }
        private void BindData()
        {
            List<USER_INFO> userInfoList = new List<USER_INFO>();
            userInfoList = userInfoService.getUserInfoList(ucPage.Index,ucPage.Size, "");
            int cCount = userInfoService.getUserInfoListCount();
            Repeater_View.DataSource = userInfoList;
            Repeater_View.DataBind();
            commonTool.ucPageVisible(ucPage, cCount);
        }
        protected void ucPage_PageIndexChanged(object sender, EventArgs e)
        {
            BindData();
        }
        protected void LinkButton_NewAccount_Click(object sender, EventArgs e)
        {
            Session["action"] = "Insert";
            TextBox_User_Id.ReadOnly = false;
            commonTool.DisplayMode(new int[] { 1 }, panelList);
        }

        public string ProcessNullDataItem(object value)
        {
            if (value == null)
            {
                return "";
            }
            return value.ToString();
        }

        protected void LinkButton_Edit_Click(object sender, EventArgs e)
        {
            Session["action"] = "Edit";
            commonTool.DisplayMode(new int[] { 1 }, panelList);
            HiddenField_Edit_cNo.Value = ((HiddenField)((LinkButton)sender).NamingContainer.FindControl("HiddenField_cNo")).Value;
            string userId = HiddenField_Edit_cNo.Value;
            USER_INFO userInfo = userInfoService.getUserInfoByUserId(userId);
            TextBox_User_Id.ReadOnly = true;
            TextBox_User_Id.Text = userInfo.USER_ID;
            TextBox_User_Address.Text = userInfo.USER_ADDRESS;
            TextBox_User_Name.Text = userInfo.USER_NAME;
            TextBox_User_Birthday.Text = userInfo.USER_BIRTHDAY.ToString();

        }

        protected void LinkButton_Del_Click(object sender, EventArgs e)
        {
            HiddenField_Edit_cNo.Value = ((HiddenField)((LinkButton)sender).NamingContainer.FindControl("HiddenField_cNo")).Value;
            bool status = userInfoService.Delete(HiddenField_Edit_cNo.Value);
            if (status)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"刪除成功\");</script>");
            }
            else
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"刪除失敗\");</script>");
            }
            BindData();
        }

        protected void Button_Submit_Click(object sender, EventArgs e)
        {
            USER_INFO userInfo = new USER_INFO();        
            userInfo.USER_ID = TextBox_User_Id.Text;
            userInfo.USER_NAME = TextBox_User_Name.Text;
            userInfo.USER_ADDRESS = TextBox_User_Address.Text;
            if (TextBox_User_Birthday.Text != "")
            {
                try{
                    userInfo.USER_BIRTHDAY = Convert.ToDateTime(TextBox_User_Birthday.Text);
                }
                catch (Exception ex)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"日期格式錯誤\");</script>");
                }               
            }           
            long seqno = 0L;
            if (Session["action"] == "Insert")
            {
                seqno = userInfoService.Insert(userInfo);
                if (seqno != 0L)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"新增成功\");</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"新增失敗\");</script>");
                }
            }
            else
            {
                seqno = userInfoService.Update(userInfo);
                if (seqno != 0L)
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"修改成功\");</script>");
                }
                else
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "show", "<script>alert(\"修改失敗\");</script>");
                }
            }
            BindData();
        }

        protected void Button_Cancel_Click(object sender, EventArgs e)
        {
            commonTool.DisplayMode(new int[] { 0 }, panelList);
        }
    }
}