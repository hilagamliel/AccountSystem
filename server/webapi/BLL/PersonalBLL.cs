using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using System.Linq;
namespace BLL
{
    public class PersonalBLL
    {
        private readonly AccountSystem accountSystem;
        public PersonalBLL(AccountSystem a)
        {
            accountSystem = a;
        }
        public List<PersonalDTO> GetAllPersonalDTO()
        {
            List<PersonalDTO> PersonaDTO = new List<PersonalDTO>();
            accountSystem.Personals.ToList().ForEach(p => PersonaDTO.Add(Cast.PersonalCast.CastPersonal(p)));
            return PersonaDTO;
        }
        public PersonalDTO GetPersonalDTO(string tz)
        {
            return Cast.PersonalCast.CastPersonal(accountSystem.Personals.Find(tz));
        }
    }
}
