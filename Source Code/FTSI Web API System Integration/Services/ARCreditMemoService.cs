using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.Base.Document;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using Microsoft.JSInterop.Infrastructure;
using NuGet.Protocol.Core.Types;

namespace FTSI_Web_API_System_Integration.Services
{
    public class ARCreditMemoService
    {
        private readonly IARCreditMemoRepository _repository;

        public ARCreditMemoService(IARCreditMemoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ARCreditMemoHeader> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        public async Task<ARCreditMemoHeader> AddAsync(ARCreditMemoItemHeaderDTO dto)
        {

            DateTime createdAt = DateTime.Now;

            // Get Lines
            List<ARCreditMemoLines> lines = new List<ARCreditMemoLines>();
            if (dto.DocumentLines != null)
            {
                int lineNum = 0;
                foreach (ARCreditMemoItemLinesDTO line in dto.DocumentLines)
                {
                    lines.Add(new()
                    {
                        LineNum = lineNum,
                        ItemCode = line.ItemCode,
                        Description = line.Description,
                        Quantity = line.Quantity,
                        PriceBefDi = line.PriceBefDi,
                        AccountCode = line.AccountCode,
                        WTLiable = line.WTLiable,
                        VatGroup = line.VatGroup,
                        U_RefNum = line.U_RefNum,
                        CreatedAt = createdAt,
                    });

                    lineNum++;
                }
            }

            // Get Header
            ARCreditMemoHeader header = new()
            {
                CardCode = dto.CardCode,
                CardName = dto.CardName,
                DocDate = dto.DocDate,
                DocDueDate = dto.DocDueDate,
                TaxDate = dto.TaxDate,
                DocRate = dto.DocRate,
                DocType = dto.DocType,
                U_RefNum = dto.U_RefNum,
                DocumentLines = lines,
                CreatedAt = createdAt,
            };

            await _repository.AddAsync(header);
            await _repository.SaveChangesAsync();

            return header;
        }

        public async Task<ARCreditMemoHeader> AddAsync(ARCreditMemoServiceHeaderDTO dto)
        {

            DateTime createdAt = DateTime.Now;

            // Get Lines
            List<ARCreditMemoLines> lines = new List<ARCreditMemoLines>();
            if (dto.DocumentLines != null)
            {
                int lineNum = 0;
                foreach (ARCreditMemoServiceLinesDTO line in dto.DocumentLines)
                {
                    lines.Add(new()
                    {
                        LineNum = lineNum,
                        ItemCode = line.ItemCode,
                        Description = line.Description,
                        Quantity = line.Quantity,
                        PriceBefDi = line.PriceBefDi,
                        AccountCode = line.AccountCode,
                        WTLiable = line.WTLiable,
                        VatGroup = line.VatGroup,
                        U_RefNum = line.U_RefNum,
                        CreatedAt = createdAt,
                    });

                    lineNum++;
                }
            }

            // Get Header
            ARCreditMemoHeader header = new()
            {
                CardCode = dto.CardCode,
                CardName = dto.CardName,
                DocDate = dto.DocDate,
                DocDueDate = dto.DocDueDate,
                TaxDate = dto.TaxDate,
                DocRate = dto.DocRate,
                DocType = dto.DocType,
                U_RefNum = dto.U_RefNum,
                DocumentLines = lines,
                CreatedAt = createdAt,
            };

            await _repository.AddAsync(header);
            await _repository.SaveChangesAsync();

            return header;
        }

        public async Task<ARCreditMemoHeader> CancelAsync(ARCreditMemoHeader entity)
        {
            // Update Cancel Field and CancelDate Field
            entity.Canceled = 'Y';
            entity.CancelDate = DateTime.Now;
            entity.IntegrationStatus = 'P';

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return entity;
        }
    }
}
