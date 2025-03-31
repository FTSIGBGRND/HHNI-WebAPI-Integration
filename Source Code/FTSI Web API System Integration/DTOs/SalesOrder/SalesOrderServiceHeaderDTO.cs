using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FTSI_Web_API_System_Integration.DTOs.SalesOrder
{
    public class SalesOrderServiceHeaderDTO
    {
        //[Required(ErrorMessage = "Business Partner is missing!!")]
        //[MaxLength(15, ErrorMessage = "Business Partner Code cannot exceed 15 characters!")]
        [MaxLength(15)]
        [Required]
        public string CardCode { get; set; }

        [MaxLength(100, ErrorMessage = "Business Partner Name cannot exceed 100 characters!")]
        public string? CardName { get; set; }

        [Required(ErrorMessage = "Document Date is missing!")]
        public DateOnly DocDate { get; set; }

        [Required(ErrorMessage = "Due Date is missing!")]
        public DateOnly DocDueDate { get; set; }

        [Required(ErrorMessage = "Tax Date is missing!")]
        public DateOnly TaxDate { get; set; }

        [DefaultValue('S')]
        [JsonIgnore]
        public char DocType { get; set; } = 'S';

        [MaxLength(3)]
        public string? DocCur { get; set; }

        [Column(TypeName = "decimal(19,6)")]
        public decimal? DocRate { get; set; }

        [MaxLength(100, ErrorMessage = "Customer Reference Number cannot exceed 100 characters!")]
        [Required]
        public string NumAtCard { get; set; }

        public int? GroupNum { get; set; }

        [MaxLength(30, ErrorMessage = "Document Reference Number cannot exceed 30 characters!")]
        [Required]
        public string U_RefNum { get; set; }

        [Required(ErrorMessage = "AR Invoice Document Line(s) is missing!")]
        public List<SalesOrderServiceLineDTO>? DocumentLines { get; set; }
    }
}
