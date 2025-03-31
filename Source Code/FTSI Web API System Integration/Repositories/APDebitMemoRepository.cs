using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;

namespace FTSI_Web_API_System_Integration.Repositories
{
    public class APDebitMemoRepository : IAPDebitMemoRepository
    {
        private readonly FTDBWContext _db;
        public APDebitMemoRepository(FTDBWContext db) => _db = db;
        public async Task AddAsync(APDebitMemoHeader creditMemo)
        {
            await _db.FTORPC.AddAsync(creditMemo);
        }

        public async Task<APDebitMemoHeader?> GetStatusAsync(Guid id)
        {
            return await _db.FTORPC.FindAsync(id);
        }

        public void Update(APDebitMemoHeader entity)
        {
            _db.FTORPC.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
