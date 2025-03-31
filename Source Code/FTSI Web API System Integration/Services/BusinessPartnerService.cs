using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.DTOs.BusinessPartner;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.BusinessPartner;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

namespace FTSI_Web_API_System_Integration.Services
{
    public class BusinessPartnerService
    {
        private readonly IBusinessPartnerRepository _repository;

        public BusinessPartnerService(IBusinessPartnerRepository repository)
        {
            _repository = repository;
        }

        public async Task<BusinessPartner?> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        public async Task<BusinessPartner> AddAsync(BusinessPartnerHeaderDTO dto)
        {
            DateTime createAt = DateTime.Now;

            // Get Contact Person
            List<ContactEmployee> contactPersons = new List<ContactEmployee>();

            if (dto.ContactEmployees != null)
            {
                foreach (ContactEmployeeDTO contactPerson in dto.ContactEmployees)
                {
                    contactPersons.Add(new()
                    {
                        Name = contactPerson.Name
                    });
                }
            }

            // Get Business Partner
            BusinessPartner bp = new()
            {
                Series = dto.Series,
                //CardCode = dto.CardCode,
                U_CompanyID = dto.U_CompanyID,
                CardName = dto.CardName,
                GroupCode = dto.GroupCode,
                Currency = dto.Currency,
                GroupNum = dto.GroupNum,
                DebPayAcct = dto.DebPayAcct,
                VatStatus = dto.VatStatus,
                ECVatGroup = dto.ECVatGroup,
                WTLiable = dto.WTLiable,
                WTCode = dto.WTCode,
                E_mail = dto.E_mail,
                Address = dto.Address,
                //CntctPrsn = dto.CntctPrsn,
                Discount = dto.Discount,
                CreatedAt = createAt,
                U_RefNum = dto.U_RefNum,
                ContactEmployees = contactPersons,
            };

            await _repository.AddAsync(bp);
            await _repository.SaveChangesAsync();

            return bp;
        }
    }
}