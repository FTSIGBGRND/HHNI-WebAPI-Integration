using FTSI_Web_API_System_Integration.Models.UserDefined.SalesBOM;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM
{
    public class ProductTree : ProductTreeUDF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string? Code { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        public char? TreeType { get; set; } = 'P';

        public DateTime CreatedAt { get; set; }


        public List<ProductTreeLine> Lines { get; set; } = [];
    }
}
