using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL.Cast
{
    public class PersonalCast
    {
        public static PersonalDTO CastPersonal(Personal personal)
        {
            PersonalDTO personalDTO = new PersonalDTO();
            personalDTO.Tz = personal.Tz;
            personalDTO.Name = personal.Name;
            personalDTO.Address = personal.Address;
            personalDTO.Email = personal.Email;
            personalDTO.Phone = personal.Phone;
            return personalDTO;
        }
        public static Personal CastPersonalDTO(PersonalDTO personalDTO)
        {
            Personal personal = new Personal();
            personal.Tz = personalDTO.Tz;
            personal.Name = personalDTO.Name;
            personal.Phone = personalDTO.Phone;
            personal.Address = personalDTO.Address;
            personal.Email = personalDTO.Email;
            return personal;
        }
    }
}
