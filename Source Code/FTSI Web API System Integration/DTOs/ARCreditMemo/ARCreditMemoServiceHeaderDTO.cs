using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.DTOs.ARCreditMemo
{
    public class ARCreditMemoServiceHeaderDTO
    {
        [MaxLength(15)]
        [Required]
        public string CardCode { get; set; }

        [MaxLength(100, ErrorMessage = "Business Partner Name cannot exceed 100 characters!")]
        public string? CardName { get; set; }

        [RegularExpression("^(S|I)$", ErrorMessage = "Invalid Value. Document Type Valid Values are S and I (S - Service | I - Items)!")]
        [DefaultValue('S')]
        [Required]
        public char DocType { get; set; } = 'S';

        [Required(ErrorMessage = "Document Date is missing!")]
        public DateOnly DocDate { get; set; }

        [Required(ErrorMessage = "Due Date is missing!")]
        public DateOnly DocDueDate { get; set; }

        [Required(ErrorMessage = "Tax Date is missing!")]
        public DateOnly TaxDate { get; set; }

        public int? GroupNum { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? DocRate { get; set; }

        [MaxLength(30, ErrorMessage = "Document Reference Number cannot exceed 30 characters!")]
        [Required]
        public string U_RefNum { get; set; }

        [Required(ErrorMessage = "AR Invoice Document Line(s) is missing!")]
        public List<ARCreditMemoServiceLinesDTO>? DocumentLines { get; set; }
    }
}
