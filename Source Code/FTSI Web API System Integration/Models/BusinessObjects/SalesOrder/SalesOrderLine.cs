using FTSI_Web_API_System_Integration.Models.Base.Document;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder
{
    public class SalesOrderLine : DocumentLines
    {
        [ForeignKey("Id")]
        public SalesOrderHeader? SalesOrder { get; set; }
    }
}
