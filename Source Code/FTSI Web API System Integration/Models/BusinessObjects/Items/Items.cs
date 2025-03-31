using FTSI_Web_API_System_Integration.Models.UserDefined.ItemUDF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.Items
{
    public class Item : ItemsUDF
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        //[MaxLength(50)]
        //[Required]
        //public string? ItemCode { get; set; }

        [MaxLength(200)]
        [Required]
        public string? ItemName { get; set; }

        public char AsstStatus { get; set; } = Helpers.AsstStatus.New;

        [MaxLength(20)]
        public string? AssetClass { get; set; }

        public char ItemType { get; set; } = Helpers.ItemType.Items;

        public int? Series { get; set; }

        public int? ItmsGrpCod { get; set; }

        public int? UgpEntry { get; set; }

        public char? InvntItem { get; set; } = 'Y';

        public char? SellItem { get; set; } = 'Y';

        public char? PrchseItem { get; set; } = 'Y';

        [MaxLength(8)]
        public string? DfltWH { get; set; }

        public char? MngMethod { get; set; } = 'N';

        [MaxLength(100)]
        public string? BuyUnitMsr { get; set; }

        [MaxLength(100)]
        public string? SalUnitMsr { get; set; }

        [MaxLength(100)]
        public string? InvntryUom { get; set; }

        public char? GLMethod { get; set; } = 'W';
        public DateTime CreatedAt { get; set; }

        public List<DepreciationParameters>? DepreciationParameters { get; set; } = [];
    }
}
