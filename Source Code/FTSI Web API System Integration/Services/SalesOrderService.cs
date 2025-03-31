using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.DTOs.SalesOrder;
using FTSI_Web_API_System_Integration.Helpers;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder;
using FTSI_Web_API_System_Integration.Repositories;
using NuGet.Protocol.Core.Types;

namespace FTSI_Web_API_System_Integration.Services
{
    public class SalesOrderService
    {
        private readonly ISalesOrderRepository _repo;

        public SalesOrderService(ISalesOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<SalesOrderHeader> GetStatusAsync(Guid id)
        {
            return await _repo.GetStatusAsync(id);
        }

        #region AddAsync Service Type
        public async Task<SalesOrderHeader> AddAsync(SalesOrderServiceHeaderDTO dto)
        {

            DateTime createdAt = DateTime.Now;
            List<SalesOrderLine> lines = [];
            SalesOrderHeader header = new();
            int lineNum = 0;

            // Get Lines
            foreach (SalesOrderServiceLineDTO line in dto.DocumentLines)
            {
                lines.Add(new()
                {
                    LineNum = lineNum,
                    ItemCode = line.ItemCode,
                    Description = line.Description,
                    Quantity = line.Quantity,
                    Price = line.Price,
                    AccountCode = line.AccountCode,
                    WTLiable = line.WTLiable,
                    VatGroup = line.VatGroup,
                    U_ArNo = line.U_ArNo,
                    U_NameOfCrew = line.U_NameOfCrew,
                    U_Peme = line.U_Peme,
                    U_Principal = line.U_Principal,
                    U_Vessel = line.U_Vessel,
                    U_Position = line.U_Position,
                    U_Age = line.U_Age,
                    OcrCode = line.OcrCode,
                    DiscPrcnt = line.DiscPrcnt,
                    U_DiscType = line.U_DiscType,
                    CreatedAt = createdAt
                });

                lineNum++;
            }
           
            // Get Header
            header.CardCode = dto.CardCode;
            header.CardName = dto.CardName;
            header.DocDate = dto.DocDate;
            header.DocDueDate = dto.DocDueDate;
            header.DocType = DocType.Service;
            header.TaxDate = dto.TaxDate;
            header.NumAtCard = dto.NumAtCard;
            header.GroupNum = dto.GroupNum;
            header.U_RefNum = dto.U_RefNum;
            header.Lines = lines;
            header.CreatedAt = createdAt;


            await _repo.AddAsync(header);
            await _repo.SaveChangesAsync();

            return header;
        }
        #endregion

        #region AddAsync Item Type
        public async Task<SalesOrderHeader> AddAsync(SalesOrderItemHeaderDTO dto)
        {

            DateTime createdAt = DateTime.Now;
            List<SalesOrderLine> lines = [];
            SalesOrderHeader header = new();
            int lineNum = 0;

            // Get Lines
            foreach (SalesOrderItemLinesDTO line in dto.DocumentLines)
            {
                lines.Add(new()
                {
                    LineNum = lineNum,
                    ItemCode = line.ItemCode,
                    Description = line.Description,
                    Quantity = line.Quantity,
                    Price = line.Price,
                    AccountCode = line.AccountCode,
                    WTLiable = line.WTLiable,
                    VatGroup = line.VatGroup,
                    U_ArNo = line.U_ArNo,
                    U_NameOfCrew = line.U_NameOfCrew,
                    U_Peme = line.U_Peme,
                    U_Principal = line.U_Principal,
                    U_Vessel = line.U_Vessel,
                    U_Position = line.U_Position,
                    U_Age = line.U_Age,
                    OcrCode = line.OcrCode,
                    DiscPrcnt = line.DiscPrcnt,
                    U_DiscType = line.U_DiscType,
                    CreatedAt = createdAt
                });

                lineNum++;
            }

            // Get Header
            header.CardCode = dto.CardCode;
            header.CardName = dto.CardName;
            header.DocDate = dto.DocDate;
            header.DocDueDate = dto.DocDueDate;
            header.DocType = DocType.Item;
            header.TaxDate = dto.TaxDate;
            header.NumAtCard = dto.NumAtCard;
            header.GroupNum = dto.GroupNum;
            header.U_RefNum = dto.U_RefNum;
            header.Lines = lines;
            header.CreatedAt = createdAt;


            await _repo.AddAsync(header);
            await _repo.SaveChangesAsync();

            return header;
        }
        #endregion

    }
}
