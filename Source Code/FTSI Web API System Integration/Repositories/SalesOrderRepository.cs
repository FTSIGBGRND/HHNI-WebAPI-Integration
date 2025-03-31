using FTSI_Web_API_System_Integration.Data;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder;

namespace FTSI_Web_API_System_Integration.Repositories
{
    public class SalesOrderRepository : ISalesOrderRepository
    {
        private readonly FTDBWContext _ftdbwcontext;
        public SalesOrderRepository(FTDBWContext ftdbwcontext) => _ftdbwcontext = ftdbwcontext;
        public async Task AddAsync(SalesOrderHeader document)
        {
            await _ftdbwcontext.FTORDR.AddAsync(document);
        }

        public async Task<SalesOrderHeader?> GetStatusAsync(Guid id)
        {
            return await _ftdbwcontext.FTORDR.FindAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ftdbwcontext.SaveChangesAsync();
        }

    }
}
