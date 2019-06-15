using log4net;
using sampleWeb.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestWeb.Models;
using TestWeb.Service.Account;

namespace sampleWeb.page.Account
{
    public partial class accountSetting : System.Web.UI.Page
    {
        AccountService accountService = new AccountService();
        static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if(!AddAccount.Text.Equals(""))
            {
                int isExsist = accountService.checkAccount(AddAccount.Text);
                if(isExsist <= 0)
                {
                    AccountDbModel accountDbModel = new AccountDbModel();
                    accountDbModel.Account = AddAccount.Text;
                    accountDbModel.AccountName = AddAccountName.Text;
                    accountDbModel.AccountType = AddAccountType.Text;
                    bool result = accountService.AddAccount(accountDbModel);
                    if(result)
                    {
                        showMessage.Text = "新增成功";
                    } else
                    {
                        showMessage.Text = "新增失敗";
                    }
                } else
                {
                    showMessage.Text = "帳號重覆";
                }
            } else
            {
                showMessage.Text = "請填寫帳號";
            }

        }

        protected void Query_Click(object sender, EventArgs e)
        {
            if(!QueryAccount.Text.Equals(""))
            {
                AccountViewModel accountDbModel = accountService.QueryAccountInfo(QueryAccount.Text);
                if(accountDbModel != null)
                {
                    UpdateAccount.Text = accountDbModel.Account;
                    UpdateAccountName.Text = accountDbModel.AccountName;
                }
                else
                {
                    showMessage.Text = "查無資料";
                }
            }
            else
            {
                showMessage.Text = "查無資料";
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if(!UpdateAccount.Text.Equals(""))
            {
                AccountDbModel accountDbModel = new AccountDbModel();
                accountDbModel.Account = UpdateAccount.Text;
                accountDbModel.AccountName = UpdateAccountName.Text;
                accountDbModel.UpdateDate = DateTime.Now;
                bool result = accountService.UpdateAccount(accountDbModel);
                if(result)
                {
                    showMessage.Text = "修改成功";
                } else
                {
                    showMessage.Text = "修改失敗";
                }               
            } else
            {
                showMessage.Text = "修改失敗";
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            if (!UpdateAccount.Text.Equals(""))
            {
                bool result = accountService.DeleteAccount(UpdateAccount.Text);
                if(result)
                {
                    showMessage.Text = "刪除成功";
                } else
                {
                    showMessage.Text = "刪除失敗";
                }
            }
            else
            {
                showMessage.Text = "刪除失敗";
            }
        }
    }
}