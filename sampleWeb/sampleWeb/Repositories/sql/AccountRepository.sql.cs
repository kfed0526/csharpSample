using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Text;

namespace TestWeb.Repositories
{
    public partial class AccountRepository : _BaseRepository<AccountDbModel>, IAccountRepository
    {
        private bool SelectAccountExsistSql(String Account)
        {
            _sqlStr = new StringBuilder();
            _sqlStr.Append("SELECT COUNT(1) FROM Account WHERE Account = @Account");

            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();
            _sqlParams.Add("Account", Account);
            return true;
        }
        private bool SelectAccountInfoSql(String Account)
        {
            _sqlStr = new StringBuilder();
            _sqlStr.Append("SELECT ActiveType,Account,AccountType,AccountName,IsDelete,RequirementNO,EffectiveStartDate,EffectiveEndDate,AccountStatus  FROM Account WHERE Account = @Account");

            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();
            _sqlParams.Add("Account", Account);
            return true;
        }
        private bool AddAccountSql(AccountDbModel accountDbModel)
        {
            _sqlStr = new StringBuilder();
            _sqlStr.Append(" INSERT INTO Account ( ");
            _sqlStr.Append("            Account ");
            _sqlStr.Append("            ,AccountType ,AccountName ");
            _sqlStr.Append("            ,IsDelete ,RequirementNO ");
            _sqlStr.Append("            ,AccountStatus ");
            _sqlStr.Append("            ,CreateDate ,CreateUserID ");
            _sqlStr.Append("            ,EffectiveStartDate ");
            _sqlStr.Append("            ,EffectiveEndDate ");
            _sqlStr.Append(" ) VALUES ( ");
            _sqlStr.Append("            @Account ");
            _sqlStr.Append("            ,@AccountType ,@AccountName ");
            _sqlStr.Append("            ,0 ,@RequirementNO ");
            _sqlStr.Append("            ,'1' ");
            _sqlStr.Append("            ,@CreateDate ,@CreateUserID ");
            _sqlStr.Append("            ,@EffectiveStartDate ");
            _sqlStr.Append("            ,@EffectiveEndDate ");
            _sqlStr.Append(" ) ");

            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();
            _sqlParams.Add("Account", accountDbModel.Account);
            _sqlParams.Add("AccountName", accountDbModel.AccountName);
            _sqlParams.Add("RequirementNO", accountDbModel.RequirementNO);
            _sqlParams.Add("AccountType", accountDbModel.AccountType);
            _sqlParams.Add("EffectiveStartDate", accountDbModel.EffectiveStartDate);
            _sqlParams.Add("EffectiveEndDate", accountDbModel.EffectiveEndDate);
            _sqlParams.Add("CreateDate", accountDbModel.CreateDate);
            _sqlParams.Add("CreateUserID", accountDbModel.CreateUserID);
            return true;
        }

        private bool UpdateAccountSql(AccountDbModel accountDbModel)
        {
            _sqlStr = new StringBuilder();
            _sqlStr.Append(" UPDATE Account SET ");
            _sqlStr.Append(" AccountName = @AccountName,");
            _sqlStr.Append(" UpdateDate = @UpdateDate");
            _sqlStr.Append(" WHERE Account = @Account");

            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();
            logger.Info("accountDbModel==" + accountDbModel.ToString());
            _sqlParams.Add("AccountName", accountDbModel.AccountName);
            _sqlParams.Add("UpdateDate", accountDbModel.UpdateDate);
            _sqlParams.Add("Account", accountDbModel.Account);
            return true;
        }

        private bool DeleteAccountSql(String Account)
        {
            _sqlStr = new StringBuilder();
            _sqlStr.Append("Delete FROM Account WHERE Account = @Account");

            //設定參數 																					  
            _sqlParams = new Dapper.DynamicParameters();
            _sqlParams.Add("Account", Account);
            return true;
        }
    }
}