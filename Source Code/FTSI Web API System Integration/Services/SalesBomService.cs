using FTSI_Web_API_System_Integration.DTOs.Items;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.Items;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM;

namespace FTSI_Web_API_System_Integration.Services
{
    public class SalesBomService
    {
        private readonly ISalesBomRepository _repository;

        public SalesBomService(ISalesBomRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductTree?> GetStatusAsync(Guid id)
        {
            return await _repository.GetStatusAsync(id);
        }

        public async Task<ProductTree> AddAsync(AddProductTreeDTO dto)
        {
            DateTime createAt = DateTime.Now;

            ProductTree salesBom = new()
            {
                Code = dto.Code,
                Name = dto.Name,
                TreeType = dto.TreeType,
                U_RefNum = dto.U_RefNum,
                CreatedAt = createAt,
            };


            List<ProductTreeLine> productTreeLines = new List<ProductTreeLine>();
            foreach (AddProductTreeLineDTO line in dto.Lines)
            {
                productTreeLines.Add(
                    new ProductTreeLine()
                    {
                        Type = line.Type,
                        ItemCode = line.ItemCode,
                        Quantity = line.Quantity,
                        Warehouse = line.Warehouse,
                        IssueMthd = line.IssueMthd,
                        ChildNum = line.ChildNum,
                    }
                    );
            }

            salesBom.Lines = productTreeLines;

            await _repository.AddAsync(salesBom);
            await _repository.SaveChangesAsync();

            return salesBom;
        }
    }
}