using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.Models.UserDefined.SalesBOM
{
    public class ProductTreeUDF
    {
        #region System
        [MaxLength(30)]
        [Required]
        public string? U_RefNum { get; set; }

        public char? IntegrationStatus { get; set; } = 'P';

        [MaxLength(255)]
        public string? IntegrationMessage { get; set; }

        #endregion
    }
}
