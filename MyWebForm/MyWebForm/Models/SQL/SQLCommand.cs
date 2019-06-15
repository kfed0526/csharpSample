using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace MyWebForm.Models.SQL
{
    public class SQLCommand
    {
        public string getUserInfoList(string ascendingColumn, string ascending)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM ( ");
            sb.Append("SELECT USER_SEQNO ");
            sb.Append(",USER_ID ");
            sb.Append(",USER_NAME ");
            sb.Append(",USER_MAIL ");
            sb.Append(",USER_ADDRESS ");
            sb.Append(",USER_BIRTHDAY ");
            sb.Append(",ROW_NUMBER() OVER (ORDER BY USER_ID) AS ROWNUM ");
            sb.Append("FROM USER_INFO ");
            sb.Append(") US ");
            sb.Append("WHERE US.ROWNUM > {0} AND US.ROWNUM <= {1} ");
            sb.Append("ORDER BY "+ ascendingColumn + " " + ascending );
            return sb.ToString();
        }
        public string getUserInfoListCount()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT USER_SEQNO ");
            sb.Append(",USER_ID ");
            sb.Append(",USER_NAME ");
            sb.Append(",USER_MAIL ");
            sb.Append(",USER_ADDRESS ");
            sb.Append(",USER_BIRTHDAY ");
            sb.Append("FROM USER_INFO ");
            return sb.ToString();
        }
    }
}