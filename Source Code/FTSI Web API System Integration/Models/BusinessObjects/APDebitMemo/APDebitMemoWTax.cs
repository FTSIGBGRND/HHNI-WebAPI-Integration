using FTSI_Web_API_System_Integration.Models.Base.Document;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo
{
    public class APDebitMemoWTax : DocumentWTax
    {
        [ForeignKey("Id")]
        public APDebitMemoHeader? DocumentHeader { get; set; }
    }
}
