using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;
using sampleWeb.Models.ViewModel;

namespace TestWeb.Repositories
{
    public partial class AccountRepository : _BaseRepository<AccountDbModel>, IAccountRepository
    {
        /// <summary>
        /// 檢查帳號是否重覆
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public int SelectAccountExsist(String Account)
        {
            SelectAccountExsistSql(Account);
            int result = 0;
            using (var cn = new MySqlConnection(_dbConn))
            {
                result = cn.Query<int>(_sqlStr.ToString(), _sqlParams).FirstOrDefault();
            }
            return result;
        }
        /// <summary>
        /// 查詢帳號資料
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        public AccountViewModel SelectAccountInfo(String Account)
        {
            SelectAccountInfoSql(Account);
            AccountViewModel accountDbModel = new AccountViewModel();
            using (var cn = new MySqlConnection(_dbConn))
            {
                accountDbModel = cn.Query<AccountViewModel>(_sqlStr.ToString(), _sqlParams).FirstOrDefault(); ;
            }
            return accountDbModel;
        }
        /// <summary>
        /// 新增帳號資料
        /// </summary>
        /// <param name="accountDbModel"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool AddAccount(AccountDbModel accountDbModel, out MySqlConnection conn, out MySqlTransaction trans)
        {
            #region 參數宣告																							   
            var result = false;
            #endregion
            conn = GetOpenConnection();
            trans = GetTransaction(conn);
            #region 流程
            try
            {
                AddAccountSql(accountDbModel);
                var ExecResult = conn.Execute(_sqlStr.ToString(), _sqlParams, trans);
                trans.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                TransactionRollback(trans);
                GetCloseConnection(conn);
                throw ex;
            }
            return result;
            #endregion
        }
        /// <summary>
        /// 修改帳號資料
        /// </summary>
        /// <param name="accountDbModel"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool UpdateAccount(AccountDbModel accountDbModel, out MySqlConnection conn, out MySqlTransaction trans)
        {
            #region 參數宣告																							   
            var result = false;
            #endregion
            conn = GetOpenConnection();
            trans = GetTransaction(conn);
            #region 流程
            try
            {
                UpdateAccountSql(accountDbModel);
                var ExecResult = conn.Execute(_sqlStr.ToString(), _sqlParams, trans);
                trans.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                TransactionRollback(trans);
                GetCloseConnection(conn);
                throw ex;
            }
            return result;
            #endregion
        }
        /// <summary>
        /// 刪除帳號資料
        /// </summary>
        /// <param name="account"></param>
        /// <param name="conn"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool DeleteAccount(String account, out MySqlConnection conn, out MySqlTransaction trans)
        {
            #region 參數宣告																							   
            var result = false;
            #endregion
            conn = GetOpenConnection();
            trans = GetTransaction(conn);
            #region 流程
            try
            {
                DeleteAccountSql(account);
                var ExecResult = conn.Execute(_sqlStr.ToString(), _sqlParams, trans);
                trans.Commit();
                result = true;
            }
            catch (Exception ex)
            {
                TransactionRollback(trans);
                GetCloseConnection(conn);
                throw ex;
            }
            return result;
            #endregion
        }
    }
}