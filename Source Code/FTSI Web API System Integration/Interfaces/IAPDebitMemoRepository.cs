using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;

namespace FTSI_Web_API_System_Integration.Interfaces
{
    public interface IAPDebitMemoRepository
    {
        Task AddAsync(APDebitMemoHeader creditMemo);
        Task<APDebitMemoHeader?> GetStatusAsync(Guid id);
        Task<int> SaveChangesAsync();
        void Update(APDebitMemoHeader entity);
    }
}