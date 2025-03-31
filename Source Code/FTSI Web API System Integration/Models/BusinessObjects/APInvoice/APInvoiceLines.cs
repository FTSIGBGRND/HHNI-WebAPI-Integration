﻿using FTSI_Web_API_System_Integration.Models.Base.Document;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice
{
    public class APInvoiceLines : DocumentLines
    {
        [ForeignKey("Id")]
        public APInvoiceHeader? APInvoiceHeader { get; set; }
    }
}
