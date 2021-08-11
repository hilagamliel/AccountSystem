using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL.Cast
{
    public class PersonalTypeCast
    {
        public static PersonalTypeDTO CastPersonalType(PersonalTypes personalTypes)
        {
            PersonalTypeDTO personalTypeDTO = new PersonalTypeDTO();
            personalTypeDTO.Id = personalTypes.Id;
            personalTypeDTO.Name = personalTypes.Name;
            return personalTypeDTO;
        }
        public static PersonalTypes CastPersonalTypeDTO(PersonalTypeDTO PersonalTypeDTO)
        {
            PersonalTypes personalTypes = new PersonalTypes();
            personalTypes.Id = PersonalTypeDTO.Id;
            personalTypes.Name = PersonalTypeDTO.Name;
            return personalTypes;
        }
    }
}
