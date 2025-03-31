using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FTSI_Web_API_System_Integration.DTOs.ARCreditMemo
{
    public class ARCreditMemoServiceLinesDTO
    {
        [Required]
        public int LineNum { get; set; }

        [MaxLength(50, ErrorMessage = "ItemCode cannot exceed 50 characters!")]
        [Required]
        public string? ItemCode { get; set; }

        [MaxLength(200, ErrorMessage = "Description cannot exceed 200 characters!")]
        [Required]
        public string? Description { get; set; }

        [MaxLength(15, ErrorMessage = "Account Code cannot exceed 15 characters!")]
        [Required]
        public string? AccountCode { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? DiscPrcnt { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? PriceBefDi { get; set; }

        [MaxLength(4, ErrorMessage = "Account Code cannot exceed 8 characters!")]
        [Required]
        public string? VatGroup { get; set; }

        [RegularExpression("^(N|Y)$", ErrorMessage = "Invalid Value. Withholding Tax Liable Valid Values are Y and N (Y - Yes | N - No)!")]
        [DefaultValue('N')]
        public char? WTLiable { get; set; }

        [MaxLength(30, ErrorMessage = "Document Line Reference Number cannot exceed 30 characters!")]
        public string? U_RefNum { get; set; }
    }
}
