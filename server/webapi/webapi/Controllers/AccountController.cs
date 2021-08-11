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
    public class AccountController : Controller
    {
        private readonly AccountSystem accountSystem;
        private readonly AccountBLL accountBLL;

        public AccountController(AccountSystem accountSystem, AccountBLL accountBLL)
        {
            this.accountSystem = accountSystem;
            this.accountBLL = accountBLL;
        }


        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PersonalDTO))]

        [HttpPost]
        public ActionResult<AccountDTO> Post(AccountDTO accountDTO)
        {
            if (accountDTO == null)
                return NotFound();
            accountSystem.Accounts.Add(BLL.Cast.AccountCast.CastAccountDTO(accountDTO
                ,accountSystem.InvestmentPolicyTypes.Find(accountDTO.IdInvestmentPolicyTypes)));
            accountSystem.SaveChanges();
            return Ok(accountSystem.Accounts.ToList().Last());
        }
    }
}
