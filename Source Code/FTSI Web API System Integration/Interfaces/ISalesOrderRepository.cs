using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder;

namespace FTSI_Web_API_System_Integration.Interfaces
{
    public interface ISalesOrderRepository
    {
        Task AddAsync(SalesOrderHeader document);
        Task<SalesOrderHeader?> GetStatusAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}