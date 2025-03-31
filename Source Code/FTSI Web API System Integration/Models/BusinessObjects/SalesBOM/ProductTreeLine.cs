using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM
{
    public class ProductTreeLine
    {
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string? ItemCode { get; set; }

        public int? Type { get; set; }

        public int? ChildNum { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? Quantity { get; set; }

        public char? IssueMthd { get; set; }

        [MaxLength(8)]
        public string? Warehouse { get; set; }

        [ForeignKey(nameof(Id))]
        public ProductTree? ProductTree { get; set; }
    }
}
