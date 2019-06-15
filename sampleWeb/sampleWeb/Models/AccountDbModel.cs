using System;
using System.Text;
using System.Web;

namespace TestWeb.Models
{
    public class AccountDbModel : _BaseModel
    {
        #region Properties
        public string ActiveType { get; set; }
        public string Account { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string IsDelete { get; set; }
        public string RequirementNO { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string AccountStatus { get; set; }

        override
        public string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ActiveType=" + ActiveType + ",");
            sb.Append("Account=" + Account + ",");
            sb.Append("UserID=" + UserID + ",");
            sb.Append("Password=" + Password + ",");
            sb.Append("AccountType=" + AccountType + ",");
            sb.Append("AccountName=" + AccountName + ",");
            sb.Append("IsDelete=" + IsDelete + ",");
            sb.Append("RequirementNO=" + RequirementNO + ",");
            sb.Append("EffectiveStartDate=" + EffectiveStartDate + ",");
            sb.Append("EffectiveEndDate=" + EffectiveEndDate + ",");
            sb.Append("AccountStatus=" + AccountStatus + "]");
            return sb.ToString();
        }
        #endregion
    }
}
