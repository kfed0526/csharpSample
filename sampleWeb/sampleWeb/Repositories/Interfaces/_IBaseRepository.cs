using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWeb.Models;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace TestWeb.Repositories
{
    public interface _IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int Id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

        MySqlConnection GetOpenConnection();
        MySqlTransaction GetTransaction(MySqlConnection conn);
        void TransactionCommit(MySqlTransaction trans);
        void TransactionRollback(MySqlTransaction trans);
        void GetCloseConnection(MySqlConnection conn);
    }
}