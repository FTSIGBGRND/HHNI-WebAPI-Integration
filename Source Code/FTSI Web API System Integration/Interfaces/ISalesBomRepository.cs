using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM;

namespace FTSI_Web_API_System_Integration.Interfaces
{
    public interface ISalesBomRepository
    {
        Task AddAsync(ProductTree salesBom);
        Task<ProductTree?> GetStatusAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}