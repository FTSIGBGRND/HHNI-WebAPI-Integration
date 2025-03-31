using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.Items
{
    public class AddItemDTO
    {
        public int? Series { get; set; }

        [MaxLength(100)]
        [Required]
        public string? U_ItemID { get; set; }

        [MaxLength(100)]
        public string? U_PackageID { get; set; }

        [MaxLength(100)]
        public string? U_ProcedureID { get; set; }

        [MaxLength(200)]
        [Required]
        public string? ItemName { get; set; }

        public int? UgpEntry { get; set; }

        public int? ItmsGrpCod { get; set; }

        [RegularExpression("^(Y|N)$", ErrorMessage = "Invalid Value. Field Valid Values are Y - Yes, N - No!")]
        [DefaultValue('Y')]
        public char? InvntItem { get; set; }

        [RegularExpression("^(Y|N)$", ErrorMessage = "Invalid Value. Field Valid Values are Y - Yes, N - No!")]
        [DefaultValue('Y')]
        public char? SellItem { get; set; }

        [RegularExpression("^(Y|N)$", ErrorMessage = "Invalid Value. Field Valid Values are Y - Yes, N - No!")]
        [DefaultValue('Y')]
        public char? PrchseItem { get; set; }

        [MaxLength(8)]
        public string? DfltWH { get; set; }

        [RegularExpression("^(Y|N)$", ErrorMessage = "Invalid Value. Field Valid Values are Y - Yes, N - No!")]
        [DefaultValue('N')]
        public char? MngMethod { get; set; } = 'N';

        [MaxLength(100)]
        public string? BuyUnitMsr { get; set; }

        [MaxLength(100)]
        public string? SalUnitMsr { get; set; }

        [MaxLength(100)]
        public string? InvntryUom { get; set; }

        [DefaultValue('W')]
        public char? GLMethod { get; set; } = 'W';

        [MaxLength(100)]
        public string? U_CustTag { get; set; }

        [MaxLength(100)]
        public string? U_Package { get; set; }

        [MaxLength(30)]
        [Required]
        public string? U_RefNum { get; set; }
    }
}
