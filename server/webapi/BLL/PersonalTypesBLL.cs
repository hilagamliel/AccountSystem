using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using System.Linq;

namespace BLL
{
    public class PersonalTypesBLL
    {
        private readonly AccountSystem accountSystem;
        public PersonalTypesBLL(AccountSystem a)
        {
            accountSystem = a;
        }

        public List<PersonalTypeDTO> GetAllPersonalTypeDTO()
        {
            List<PersonalTypeDTO> PersonalTypeDTO = new List<PersonalTypeDTO>();
            accountSystem.PersonalTypes.ToList().ForEach(r => 
            PersonalTypeDTO.Add(Cast.PersonalTypeCast.CastPersonalType(r)));
            return PersonalTypeDTO;
        }
        public PersonalTypeDTO GetPersonalTypeDTO(int id)
        {
            return Cast.PersonalTypeCast.CastPersonalType(accountSystem.PersonalTypes.Find(id));
        }
    }
}
