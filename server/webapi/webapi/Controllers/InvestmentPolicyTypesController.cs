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
    public class InvestmentPolicyTypesController : Controller
    {
        private readonly AccountSystem accountSystem;
        private readonly InvestmentPolicyTypesBLL investmentPolicyTypesBLL;

        public InvestmentPolicyTypesController(AccountSystem accountSystem, InvestmentPolicyTypesBLL investmentPolicyTypesBLL)
        {
            this.accountSystem = accountSystem;
            this.investmentPolicyTypesBLL = investmentPolicyTypesBLL;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [HttpPost]
        public ActionResult<InvestmentPolicyTypesDTO> Post(InvestmentPolicyTypesDTO investmentPolicyTypesDTO)
        {
            if (investmentPolicyTypesDTO == null)
                return NotFound();
            accountSystem.InvestmentPolicyTypes.Add(BLL.Cast.InvestmentPolicyTypesCast.CastInvestmentPolicyTypesDTO(investmentPolicyTypesDTO));
            accountSystem.SaveChanges();
            return Ok(investmentPolicyTypesDTO);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonalDTO))]
        [HttpGet]
        public ActionResult<IEnumerable<InvestmentPolicyTypesDTO>> Get()
        {
            return Ok(investmentPolicyTypesBLL.GetAllInvestmentPolicyTypesDTO());
        }

    }
}
