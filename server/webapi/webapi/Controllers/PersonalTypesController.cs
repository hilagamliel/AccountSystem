using DAL;
using BLL;
using DTO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("AccountSystems")]
    public class PersonalTypesController : Controller
    {
        private readonly AccountSystem accountSystem;
        private readonly PersonalTypesBLL personalTypesBLL;

        public PersonalTypesController(AccountSystem accountSystem, PersonalTypesBLL personalTypesBLL)
        {
            this.accountSystem = accountSystem;
            this.personalTypesBLL = personalTypesBLL;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [HttpPost]
        public ActionResult<PersonalTypeDTO> Post(PersonalTypeDTO personalTypeDTO)
        {
            if (personalTypeDTO == null)
                return NotFound();
            accountSystem.PersonalTypes.Add(BLL.Cast.PersonalTypeCast.CastPersonalTypeDTO(personalTypeDTO));
            accountSystem.SaveChanges();
            return Ok(personalTypeDTO);
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [HttpGet]
        public ActionResult<IEnumerable<PersonalTypeDTO>> Get()
        {
            return Ok(personalTypesBLL.GetAllPersonalTypeDTO());
        }
    }
}
