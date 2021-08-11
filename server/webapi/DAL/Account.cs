using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagementFee { get; set; }
        public int BankNumber { get; set; }
        public int BankAccountNumber { get; set; }
        public virtual InvestmentPolicyTypes InvestmentPolicyTypes { get; set; }
    }
}
