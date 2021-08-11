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
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("AccountSystems")]
    public class PersonalController : Controller
    {
        private readonly AccountSystem RepositoryContext;
        private readonly PersonalBLL personalBLL;

        public PersonalController(AccountSystem accountSystem, PersonalBLL personalBLL)
        {
            this.RepositoryContext = accountSystem;
            this.personalBLL = personalBLL;
        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [HttpPost]
        public ActionResult<PersonalDTO> Post(PersonalDTO personal)
        {
            if (personal == null)
                return NotFound();
            Personal p = BLL.Cast.PersonalCast.CastPersonalDTO(personal);
            Personal p1 = RepositoryContext.Personals.Find(p.Tz);

            // if exist os update
            if (p1 != null)
            {
                p1.Phone = p.Phone;
                p1.Email = p.Email;
                p1.Name = p.Name;
                p1.Tz = p.Tz;
                p1.Address = p.Address;
                //var updatedEntity = RepositoryContext.Set<Personal>().Update(p);//This line is goes to catch error block
                //updatedEntity.State = EntityState.Modified;
            }
                //RepositoryContext.Entry(p).State = EntityState.Modified;
            else
                RepositoryContext.Personals.Add(BLL.Cast.PersonalCast.CastPersonalDTO(personal));
            RepositoryContext.SaveChanges();
            return Ok(personal);
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [HttpGet]
        public ActionResult<IEnumerable<PersonalDTO>> Get()
        {
            return Ok(personalBLL.GetAllPersonalDTO());
        }
    }
}
