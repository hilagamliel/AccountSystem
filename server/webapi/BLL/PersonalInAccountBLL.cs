using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using System.Linq;

namespace BLL
{
    public class PersonalInAccountBLL
    {
        private readonly AccountSystem accountSystem;
        public PersonalInAccountBLL(AccountSystem a)
        {
            accountSystem = a;
        }
        public List<PersonalInAccountDTO> GetAllPersonalInAccountDTO()
        {
            List<PersonalInAccountDTO> PersonalInAccountDTO = new List<PersonalInAccountDTO>();
            accountSystem.PersonalInAccounts.ToList().ForEach(p => PersonalInAccountDTO.Add(Cast.PersonalInAccountCast.CastPersonalInAccount(p)));
            return PersonalInAccountDTO;
        }
        public PersonalInAccountDTO GetPersonalInAccountDTO(int id)
        {
            return Cast.PersonalInAccountCast.CastPersonalInAccount(accountSystem.PersonalInAccounts.Find(id));
        }
    }
}
