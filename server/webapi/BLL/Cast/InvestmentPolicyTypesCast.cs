using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
namespace BLL.Cast
{
    public class InvestmentPolicyTypesCast
    {
        public static InvestmentPolicyTypesDTO CastInvestmentPolicyTypes(InvestmentPolicyTypes investment_PolicyTypes)
        {
            InvestmentPolicyTypesDTO investmentPolicyTypesDTO = new InvestmentPolicyTypesDTO();
            investmentPolicyTypesDTO.Id = investment_PolicyTypes.Id;
            investmentPolicyTypesDTO.Name = investment_PolicyTypes.Name;
            return investmentPolicyTypesDTO;
        }
        public static InvestmentPolicyTypes CastInvestmentPolicyTypesDTO(InvestmentPolicyTypesDTO investmentPolicyTypesDTO)
        {
            InvestmentPolicyTypes InvestmentPolicyTypes = new InvestmentPolicyTypes();
            InvestmentPolicyTypes.Id = investmentPolicyTypesDTO.Id;
            InvestmentPolicyTypes.Name = investmentPolicyTypesDTO.Name;
            return InvestmentPolicyTypes;
        }
    }
}
