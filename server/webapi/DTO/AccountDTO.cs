using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagementFee { get; set; }
        public int BankNumber { get; set; }
        public int BankAccountNumber { get; set; }
        public string NameInvestmentPolicyTypes { get; set; }
        public int IdInvestmentPolicyTypes { get; set; }

    }
}
