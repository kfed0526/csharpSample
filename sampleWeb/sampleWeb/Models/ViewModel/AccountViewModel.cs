using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sampleWeb.Models.ViewModel
{
    public class AccountViewModel
    {
        public string ActiveType { get; set; }
        public string Account { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string IsDelete { get; set; }
        public string RequirementNO { get; set; }
        public string EffectiveStartDate { get; set; }
        public string EffectiveEndDate { get; set; }
        public string AccountStatus { get; set; }
    }
}