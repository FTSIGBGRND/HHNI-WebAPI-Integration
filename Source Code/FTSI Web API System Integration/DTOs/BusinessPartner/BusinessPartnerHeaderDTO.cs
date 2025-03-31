using FTSI_Web_API_System_Integration.DTOs.Retirement;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.BusinessPartner;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.DTOs.BusinessPartner
{
    public class BusinessPartnerHeaderDTO
    {
        public int? Series { get; set; }

        //[MaxLength(15)]
        //[Required]
        //public string? CardCode { get; set; }

        [Required]
        public int? U_CompanyID { get; set; }

        [MaxLength(100)]
        [Required]
        public string? CardName { get; set; }

        [Required]
        public int? GroupCode { get; set; }

        [MaxLength(3)]
        [Required]
        public string? Currency { get; set; }
        public int? GroupNum { get; set; }

        [MaxLength(15)]
        [Required]
        public string? DebPayAcct { get; set; }

        [RegularExpression("^(Y|N)$", ErrorMessage = "Invalid Value. Field Valid Values are Y - Yes, N - No!")]
        [DefaultValue('Y')]
        public char? VatStatus { get; set; }

        [MaxLength(8)]
        public string? ECVatGroup { get; set; }

        [RegularExpression("^(Y|N)$", ErrorMessage = "Invalid Value. Field Valid Values are Y - Yes, N - No!")]
        [Required]
        [DefaultValue('N')]
        public char? WTLiable { get; set; }

        [MaxLength(4)]
        public string? WTCode { get; set; }

        [MaxLength(100)]
        public string? E_mail { get; set; }

        [MaxLength(100)]
        public string? Address { get; set; }

        //[MaxLength(90)]
        //public string? CntctPrsn { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? Discount { get; set; }

        [MaxLength(30)]
        [Required]
        public string? U_RefNum { get; set; }

        public List<ContactEmployeeDTO>? ContactEmployees { get; set; } = [];
    }
}
