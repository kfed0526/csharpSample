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
    interface IAccountRepository : _IBaseRepository<AccountDbModel>
    {
        int SelectAccountExsist(String Account);

        AccountViewModel SelectAccountInfo(String Account);

        bool AddAccount(AccountDbModel accountDbModel, out MySqlConnection conn, out MySqlTransaction trans);

        bool UpdateAccount(AccountDbModel accountDbModel, out MySqlConnection conn, out MySqlTransaction trans);

        bool DeleteAccount(String Account, out MySqlConnection conn, out MySqlTransaction trans);
    }
}