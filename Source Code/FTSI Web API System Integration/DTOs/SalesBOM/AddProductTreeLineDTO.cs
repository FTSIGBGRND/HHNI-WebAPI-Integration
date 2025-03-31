using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.DTOs.Items
{
    public class AddProductTreeLineDTO
    {
        [MaxLength(50)]
        public string? ItemCode { get; set; }

        public int? Type { get; set; }

        public int? ChildNum { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? Quantity { get; set; }

        [MaxLength(8)]
        public string? Warehouse { get; set; }

        [DefaultValue(null)]
        public char? IssueMthd { get; set; }
    }
}
