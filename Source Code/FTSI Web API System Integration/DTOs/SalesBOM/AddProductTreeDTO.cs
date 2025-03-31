using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.DTOs.Items
{
    public class AddProductTreeDTO
    {
        [MaxLength(50)]
        [Required]
        public string? Code { get; set; }

        [MaxLength(200)]
        public string? Name { get; set; }

        [DefaultValue('A')]
        public char? TreeType { get; set; }

        [MaxLength(30)]
        [Required]
        public string? U_RefNum { get; set; }

        public List<AddProductTreeLineDTO> Lines { get; set; } = [];
    }
}
