using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FTSI_Web_API_System_Integration.DTOs.ARInvoice
{
    public class SalesOrderItemLinesDTO
    {
        [Required]
        public int LineNum { get; set; }

        [MaxLength(50)]
        [Required]
        public string? ItemCode { get; set; }

        [MaxLength(200)]
        [Required]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        [Required]
        public decimal? Quantity { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        [Required]
        public decimal? Price { get; set; }

        [MaxLength(15)]
        [Required]
        public string? AccountCode { get; set; }

        [Required]
        [DefaultValue('N')]
        public char? WTLiable { get; set; }

        [MaxLength(8)]
        [Required]
        public string? VatGroup { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_ArNo { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_NameOfCrew { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_Peme { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_Principal { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_Vessel { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_Age { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_Position { get; set; }

        [MaxLength(15)]
        public string? U_DiscType { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? DiscPrcnt { get; set; }

        [MaxLength(8)]
        [Required]
        public string? OcrCode { get; set; }
    }
}
