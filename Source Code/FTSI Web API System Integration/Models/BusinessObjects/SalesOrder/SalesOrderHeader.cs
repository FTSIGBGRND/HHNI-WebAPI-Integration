using FTSI_Web_API_System_Integration.Models.Base.Document;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder
{
    public class SalesOrderHeader : DocumentHeader
    {
        public List<SalesOrderLine> Lines { get; set; } = [];
    }
}
