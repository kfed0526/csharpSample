using System;
using MySql.Data.MySqlClient;
using System.Web;
using TestWeb.Models;
using TestWeb.Repositories;
using sampleWeb.Models.ViewModel;

namespace TestWeb.Service.Account
{
    public class AccountService
    {
        IAccountRepository accountRepository = new AccountRepository();
        
        public int checkAccount(String account)
        {
            int result = accountRepository.SelectAccountExsist(account);
            return result;
        }
        /// <summary>																  
        /// 查詢帳號資料															  
        /// </summary>																  
        /// <param name="Account"></param>											  
        /// <returns>AccountDbModel</returns>	
        public AccountViewModel QueryAccountInfo(String account)
        {
            AccountViewModel accountDbModel = accountRepository.SelectAccountInfo(account);
            return accountDbModel;
        }

        /// <summary>																  
        /// 新增帳號資料															  
        /// </summary>																  
        /// <param name="AccountDbModel"></param>											  
        /// <returns>boolean</returns>														  
        public bool AddAccount(AccountDbModel accountDbModel)
        {      
            MySqlConnection conn = null;
            MySqlTransaction trans = null;
            String requirementNO = "USER" + DateTime.Now.ToString("yyyyMMddHHmmss"); //自訂單號
            accountDbModel.RequirementNO = requirementNO;
            return accountRepository.AddAccount(accountDbModel, out conn, out trans);
        }
        /// <summary>																  
        /// 修改帳號資料															  
        /// </summary>																  
        /// <param name="AccountDbModel"></param>											  
        /// <returns>boolean</returns>														  
        public bool UpdateAccount(AccountDbModel accountDbModel)
        {
            MySqlConnection conn = null;
            MySqlTransaction trans = null;
            return accountRepository.UpdateAccount(accountDbModel, out conn, out trans);
        }
        /// <summary>																  
        /// 刪除帳號資料															  
        /// </summary>																  
        /// <param name="Account"></param>											  
        /// <returns>boolean</returns>														  
        public bool DeleteAccount(String Account)
        {
            MySqlConnection conn = null;
            MySqlTransaction trans = null;
            return accountRepository.DeleteAccount(Account, out conn, out trans);
        }
    }
}
