using FTSI_Web_API_System_Integration.DTOs.ARCreditMemo;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;

namespace FTSI_Web_API_System_Integration.Services
{
    public class APDebitMemoService
    {
        private readonly IAPDebitMemoRepository _repository;

        public APDebitMemoService(IAPDebitMemoRepository repository)
        {
            _repository = repository;
        }

        public async Task<APDebitMemoHeader?> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        public async Task<APDebitMemoHeader> AddAsync(APDebitMemoItemHeaderDTO dto)
        {

            DateTime createdAt = DateTime.Now;

            // Get Lines
            List<APDebitMemoLines> lines = new List<APDebitMemoLines>();
            if (dto.DocumentLines != null)
            {

                foreach (APDebitMemoItemLinesDTO line in dto.DocumentLines)
                {
                    lines.Add(new()
                    {
                        LineNum = line.LineNum,
                        ItemCode = line.ItemCode,
                        AccountCode = line.AccountCode,
                        U_BaseType = line.U_BaseType,
                        U_BaseRef = line.U_BaseRef,
                        U_BaseLine = line.U_BaseLine,
                        Description = line.Description,
                        DiscPrcnt = line.DiscPrcnt,
                        Quantity = line.Quantity,
                        Price = line.Price,
                        VatGroup = line.VatGroup,
                        PriceAfVAT = line.PriceAfVAT,
                        WTLiable = line.WTLiable,
                        OcrCode = line.OcrCode,
                        OcrCode2 = line.OcrCode2,
                        OcrCode3 = line.OcrCode3,
                        OcrCode4 = line.OcrCode4,
                        OcrCode5 = line.OcrCode5,
                        U_RefNum = line.U_RefNum,
                        U_LngDscrptn = line.U_LongDscrptn,
                        U_Period = line.U_Period,
                        CreatedAt = createdAt,
                    });
                }
            }

            // Get WTax
            APDebitMemoWTax wtax = new APDebitMemoWTax();
            if (dto.DocumentWTax != null)
            {
                wtax = new()
                {
                    WTCode = dto.DocumentWTax.WTCode,
                    TaxbleAmnt = dto.DocumentWTax.TaxbleAmnt,
                    WTAmnt = dto.DocumentWTax.WTAmnt,
                    U_RefNum = dto.DocumentWTax.RefNum,
                    CreatedAt = createdAt,
                };
            }

            // Get Header
            APDebitMemoHeader header = new()
            {
                CardCode = dto.CardCode,
                CardName = dto.CardName,
                DocDate = dto.DocDate,
                DocDueDate = dto.DocDueDate,
                TaxDate = dto.TaxDate,
                NumAtCard = dto.NumAtCard,
                DocType = dto.DocType,
                JrnlMemo = dto.JrnlMemo,
                Comments = dto.Comments,
                U_RefNum = dto.U_RefNum,
                U_FileName = dto.U_FileName,
                DocumentLines = lines,
                DocumentWTax = wtax,
                CreatedAt = createdAt,
            };

            await _repository.AddAsync(header);
            await _repository.SaveChangesAsync();

            return header;
        }

        public async Task<APDebitMemoHeader> AddAsync(APDebitMemoServiceHeaderDTO dto)
        {

            DateTime createdAt = DateTime.Now;

            // Get Lines
            List<APDebitMemoLines> lines = new List<APDebitMemoLines>();
            if (dto.DocumentLines != null)
            {
                foreach (APDebitMemoServiceLinesDTO line in dto.DocumentLines)
                {
                    lines.Add(new()
                    {
                        LineNum = line.LineNum,
                        AccountCode = line.AccountCode,
                        U_BaseType = line.U_BaseType,
                        U_BaseRef = line.U_BaseRef,
                        U_BaseLine = line.U_BaseLine,
                        Description = line.Description,
                        DiscPrcnt = line.DiscPrcnt,
                        Quantity = line.Quantity,
                        Price = line.Price,
                        VatGroup = line.VatGroup,
                        PriceAfVAT = line.PriceAfVAT,
                        WTLiable = line.WTLiable,
                        OcrCode = line.OcrCode,
                        OcrCode2 = line.OcrCode2,
                        OcrCode3 = line.OcrCode3,
                        OcrCode4 = line.OcrCode4,
                        OcrCode5 = line.OcrCode5,
                        U_RefNum = line.U_RefNum,
                        U_LngDscrptn = line.U_LongDscrptn,
                        U_Period = line.U_Period,
                        CreatedAt = createdAt,
                    });
                }
            }

            // Get WTax
            APDebitMemoWTax wtax = new APDebitMemoWTax();
            if (dto.DocumentWTax != null)
            {
                wtax = new()
                {
                    WTCode = dto.DocumentWTax.WTCode,
                    TaxbleAmnt = dto.DocumentWTax.TaxbleAmnt,
                    WTAmnt = dto.DocumentWTax.WTAmnt,
                    U_RefNum = dto.DocumentWTax.RefNum,
                    CreatedAt = createdAt,
                };
            }

            // Get Header
            APDebitMemoHeader header = new()
            {
                CardCode = dto.CardCode,
                CardName = dto.CardName,
                DocDate = dto.DocDate,
                DocDueDate = dto.DocDueDate,
                TaxDate = dto.TaxDate,
                NumAtCard = dto.NumAtCard,
                DocType = DocType.Service,
                JrnlMemo = dto.JrnlMemo,
                Comments = dto.Comments,
                U_RefNum = dto.U_RefNum,
                U_FileName = dto.U_FileName,
                DocumentLines = lines,
                DocumentWTax = wtax,
                CreatedAt = createdAt,
            };

            await _repository.AddAsync(header);
            await _repository.SaveChangesAsync();

            return header;
        }

        public async Task<APDebitMemoHeader> CancelAsync(APDebitMemoHeader entity)
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
