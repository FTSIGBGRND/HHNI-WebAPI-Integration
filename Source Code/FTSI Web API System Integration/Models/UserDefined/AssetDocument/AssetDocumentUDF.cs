﻿using System.ComponentModel.DataAnnotations;

namespace FTSI_Web_API_System_Integration.Models.UserDefined.AssetDocument
{
    public class AssetDocumentUDF
    {
        [MaxLength(30)]
        [Required]
        public string? U_RefNum { get; set; }

        public char IntegrationStatus { get; set; } = 'P';

        public string? IntegrationMessage { get; set; }
    }
}
