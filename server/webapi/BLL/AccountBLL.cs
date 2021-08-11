using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using System.Linq;

namespace BLL
{
    public class AccountBLL
    {
        private readonly AccountSystem accountSystem;
        public AccountBLL(AccountSystem a)
        {
            accountSystem = a;
        }
        public List<AccountDTO> GetAllAccountDTO()
        {
            List<AccountDTO> accountDTOs = new List<AccountDTO>();
            accountSystem.Accounts.ToList().ForEach(a =>
            accountDTOs.Add(Cast.AccountCast.CastAccount(a)));
            return accountDTOs;
        }
        public AccountDTO GetAccountDTO(int id)
        {
            return Cast.AccountCast.CastAccount(accountSystem.Accounts.Find(id));
        }
    }
}
