using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using System.Linq;

namespace BLL
{
    public class InvestmentPolicyTypesBLL
    {
        private readonly AccountSystem accountSystem;
        public InvestmentPolicyTypesBLL(AccountSystem a)
        {
            accountSystem = a;
        }
        public List<InvestmentPolicyTypesDTO> GetAllInvestmentPolicyTypesDTO()
        {
            List<InvestmentPolicyTypesDTO> investmentPolicyTypesDTOs = new List<InvestmentPolicyTypesDTO>();
            accountSystem.InvestmentPolicyTypes.ToList().ForEach(i =>
            investmentPolicyTypesDTOs.Add(Cast.InvestmentPolicyTypesCast.CastInvestmentPolicyTypes(i)));
            return investmentPolicyTypesDTOs;
        }
        public InvestmentPolicyTypesDTO GetInvestmentPolicyTypesDTO(int id)
        {
            return Cast.InvestmentPolicyTypesCast.CastInvestmentPolicyTypes(accountSystem.InvestmentPolicyTypes.Find(id));
        }
    }
}
