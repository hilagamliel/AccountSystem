using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL.Cast
{
    public class PersonalInAccountCast
    {
        public static PersonalInAccountDTO CastPersonalInAccount(PersonalInAccount personalInAccount)
        {
            PersonalInAccountDTO personalInAccountDTO = new PersonalInAccountDTO();
            personalInAccountDTO.Id = personalInAccount.Id;
            personalInAccountDTO.IdAccount = personalInAccount.Account.Id;
            personalInAccountDTO.IdPersonalTypes = personalInAccount.PersonalTypes.Id;
            personalInAccountDTO.TzPersonal = personalInAccount.Personal.Tz;
            return personalInAccountDTO;
        }
        public static PersonalInAccount CastPersonalInAccountDTO(PersonalInAccountDTO PersonalInAccount,
            Account account,Personal personal,PersonalTypes personalTypes)
        {
            PersonalInAccount personalInAccount = new PersonalInAccount();
            personalInAccount.Id = PersonalInAccount.Id;
            if (PersonalInAccount.IdAccount != account.Id)
                return null;
            personalInAccount.Account = account;
            if (PersonalInAccount.IdPersonalTypes != personalTypes.Id )
                return null;

            personalInAccount.PersonalTypes = personalTypes;
            if (PersonalInAccount.TzPersonal != personal.Tz)
                return null;
            personalInAccount.Personal = personal;

            return personalInAccount;
        }
    }
}
