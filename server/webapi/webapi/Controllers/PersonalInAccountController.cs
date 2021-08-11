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
    public class PersonalInAccountController : Controller
    {
        private readonly AccountSystem accountSystem;
        private readonly PersonalInAccountBLL personalInAccountBLL;

        public PersonalInAccountController(AccountSystem accountSystem, PersonalInAccountBLL personalInAccountBLL)
        {
            this.accountSystem = accountSystem;
            this.personalInAccountBLL = personalInAccountBLL;
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PersonalDTO))]

        [HttpPost]
        public ActionResult<PersonalInAccountDTO> Post(PersonalInAccountDTO personalInAccountDTO)
        {
            if (personalInAccountDTO == null)
                return NotFound();
            accountSystem.PersonalInAccounts.Add(BLL.Cast.PersonalInAccountCast.CastPersonalInAccountDTO(personalInAccountDTO
                , accountSystem.Accounts.Find(personalInAccountDTO.IdAccount),
                accountSystem.Personals.Find(personalInAccountDTO.TzPersonal),
                accountSystem.PersonalTypes.Find(personalInAccountDTO.IdPersonalTypes)));
            accountSystem.SaveChanges();
            return Ok(personalInAccountDTO);
        }
    }
}
