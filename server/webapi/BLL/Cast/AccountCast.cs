using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL.Cast
{
    public class AccountCast
    {
        public static AccountDTO CastAccount(Account account)
        {
            AccountDTO accountDTO = new AccountDTO();
            accountDTO.Id = account.Id;
            accountDTO.Name = account.Name;
            accountDTO.BankAccountNumber = account.BankAccountNumber;
            accountDTO.BankNumber = account.BankNumber;
            accountDTO.ManagementFee = account.ManagementFee;
            accountDTO.NameInvestmentPolicyTypes = account.InvestmentPolicyTypes.Name;
            accountDTO.IdInvestmentPolicyTypes = account.InvestmentPolicyTypes.Id;

            return accountDTO;
        }
        public static Account CastAccountDTO(AccountDTO accountDTO,InvestmentPolicyTypes investmentPolicyTypes)
        {
            Account account = new Account();
            account.Id = accountDTO.Id;
            account.Name = accountDTO.Name;
            account.ManagementFee = accountDTO.ManagementFee;
            account.BankNumber = accountDTO.BankNumber;
            account.BankAccountNumber = accountDTO.BankAccountNumber;
            account.InvestmentPolicyTypes = investmentPolicyTypes;
            return account;
        }
    }
}
