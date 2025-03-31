using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.Items;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM;

namespace FTSI_Web_API_System_Integration.Repositories
{
    public class SalesBomRepository : ISalesBomRepository
    {
        private readonly FTDBWContext _db;
        public SalesBomRepository(FTDBWContext db) => _db = db;
        public async Task AddAsync(ProductTree salesBom)
        {
            await _db.FTOITT.AddAsync(salesBom);
        }

        public async Task<ProductTree?> GetStatusAsync(Guid id)
        {
            return await _db.FTOITT.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}
