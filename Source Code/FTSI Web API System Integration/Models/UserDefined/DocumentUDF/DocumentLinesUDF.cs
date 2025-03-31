using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FTSI_Web_API_System_Integration.Models.UserDefined.DocumentUDF
{
    public class DocumentLinesUDF
    {
        #region User-Defined Fields
        [MaxLength(30)]
        public string? U_RefNum { get; set; }

        public int? U_BaseRef { get; set; }

        public int? U_BaseType { get; set; }
        public int? U_BaseLine { get; set; }

        public string? U_LngDscrptn { get; set; }

        [MaxLength(10)]
        public string? U_Period { get; set; }
        #endregion

        #region HALCYON
        [MaxLength(100)]
        public string? U_ArNo { get; set; }

        [MaxLength(100)]
        public string? U_NameOfCrew { get; set; }

        [MaxLength(100)]
        public string? U_Peme { get; set; }

        [MaxLength(100)]
        public string? U_Principal { get; set; }

        [MaxLength(100)]
        public string? U_Vessel { get; set; }

        [MaxLength(100)]
        public string? U_Age { get; set; }

        [MaxLength (100)]
        public string? U_Position { get; set; }

        [MaxLength(15)]
        public string? U_DiscType { get; set; }
        #endregion
    }
}
