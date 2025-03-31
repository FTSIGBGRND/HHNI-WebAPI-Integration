using FTSI_Web_API_System_Integration.Models.Base.Document;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo
{
    public class APDebitMemoHeader : DocumentHeader
    {
        public List<APDebitMemoLines> DocumentLines { get; set; } = new();
        public APDebitMemoWTax? DocumentWTax { get; set; }
    }
}
