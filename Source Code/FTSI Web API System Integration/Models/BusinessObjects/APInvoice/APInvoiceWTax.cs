using FTSI_Web_API_System_Integration.Models.Base.Document;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice
{
    public class APInvoiceWTax : DocumentWTax
    {
        [ForeignKey("Id")]
        public APInvoiceHeader? APInvoiceHeader { get; set; }
    }
}
