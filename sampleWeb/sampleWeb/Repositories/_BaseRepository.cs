using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web;
using TestWeb.Repositories;
using log4net;

namespace TestWeb.Models
{
    public class _BaseRepository<TEntity> : _IBaseRepository<TEntity> where TEntity : class
    {
        protected static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected StringBuilder _sqlStr;
        protected string _sqlOrderByStr;
        protected MySqlConnection SQLConnection;
        protected MySqlTransaction SQLTransaction;
        protected DynamicParameters _sqlParams;
        protected List<DynamicParameters> _sqlParamsList;

        protected string _dbConn = ConfigurationManager.ConnectionStrings["myDbConnect"].ConnectionString;

        public MySqlConnection GetOpenConnection()
        {
            SQLConnection = new MySqlConnection(_dbConn);
            if (SQLConnection.State != ConnectionState.Open)
                SQLConnection.Open();
            return SQLConnection;
        }

        public MySqlTransaction GetTransaction(MySqlConnection conn)
        {
            SQLTransaction = conn.BeginTransaction();
            return SQLTransaction;
        }

        public void TransactionCommit(MySqlTransaction trans)
        {
            trans.Commit();
        }

        public void TransactionRollback(MySqlTransaction trans)
        {
            trans.Rollback();
        }

        public void GetCloseConnection(MySqlConnection conn)
        {
            conn.Close();
            conn.Dispose();
        }

        TEntity _IBaseRepository<TEntity>.Get(int Id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> _IBaseRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

        void _IBaseRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void _IBaseRepository<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void _IBaseRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        MySqlConnection _IBaseRepository<TEntity>.GetOpenConnection()
        {
            throw new NotImplementedException();
        }

        MySqlTransaction _IBaseRepository<TEntity>.GetTransaction(MySqlConnection conn)
        {
            throw new NotImplementedException();
        }

        void _IBaseRepository<TEntity>.TransactionCommit(MySqlTransaction trans)
        {
            throw new NotImplementedException();
        }

        void _IBaseRepository<TEntity>.TransactionRollback(MySqlTransaction trans)
        {
            throw new NotImplementedException();
        }

        void _IBaseRepository<TEntity>.GetCloseConnection(MySqlConnection conn)
        {
            throw new NotImplementedException();
        }
    }
}
