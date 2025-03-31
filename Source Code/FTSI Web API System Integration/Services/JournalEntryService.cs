using FTSI_Web_API_System_Integration.DTOs.JournalEntry;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.BusinessPartner;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.JournalEntry;

namespace FTSI_Web_API_System_Integration.Services
{
    public class JournalEntryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public JournalEntryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<JournalEntry> AddJournalEntryAsync(AddJournalEntryDTO journalDto)
        {
            DateTime createdAt = DateTime.Now;

            // Journal
            JournalEntry? journal = new JournalEntry();
            journal.U_DocNum = journalDto.U_DocNum;
            journal.RefDate = journalDto.RefDate;
            journal.Memo = journalDto.Memo;
            journal.CreatedAt = createdAt;
            journal.U_RefNum = journalDto.U_RefNum;


            // Journal Lines
            JournalEntryLine? journalLine = new JournalEntryLine();
            journalLine.LineId = 0;
            journalLine.ShortName = journalDto.ShortName;
            journalLine.Account = journalDto.Account;
            journalLine.LineMemo = journalDto.LineMemo;
            journalLine.Debit = journalDto.Debit;
            journalLine.Credit = journalDto.Credit;
            journalLine.FCCurrency = journalDto.FCCurrency;
            journalLine.ProfitCode = journalDto.ProfitCode;
            journalLine.OcrCode2 = journalDto.OcrCode2;
            journalLine.OcrCode3 = journalDto.OcrCode3;
            journalLine.OcrCode4 = journalDto.OcrCode4;
            journalLine.OcrCode5 = journalDto.OcrCode5;
            journalLine.U_InvDate = journalDto.U_InvDate;
            journalLine.U_InvNum = journalDto.U_InvNum;
            journalLine.U_VatBase = journalDto.U_VatBase;
            journalLine.TransType = journalDto.U_TransType;
            journalLine.U_xWTCode = journalDto.U_xWTCode;
            journalLine.U_xWTVendor = journalDto.U_xWTVendor;
            journalLine.U_xSupplierName = journalDto.U_xSupplierName;
            journalLine.U_xCardTyp = journalDto.U_xCardTyp;
            journalLine.U_Address = journalDto.U_Address;
            journalLine.U_TIN = journalDto.U_TIN;
            journalLine.U_TIN1 = journalDto.U_TIN1;
            journalLine.U_TIN2 = journalDto.U_TIN2;
            journalLine.U_TaxAmt = journalDto.U_TaxAmt;
            journalLine.U_TaxableAmt = journalDto.U_TaxableAmt;
            journalLine.U_SrceDocNo = journalDto.U_SrceDocNo;
            journalLine.U_ORNo = journalDto.U_ORNo;
            journalLine.U_SOA = journalDto.U_SOA;
            journalLine.U_CheckNo = journalDto.U_CheckNo;
            journalLine.U_CheckDate = journalDto.U_CheckDate;
            journalLine.U_APVNo = journalDto.U_APVNo;
            journalLine.U_VSIRefNo = journalDto.U_VSIRefNo;
            journalLine.U_Contract = journalDto.U_Contract;
            journalLine.CreatedAt = createdAt;

            // Add Journal Lines to Journal Header
            journal.Lines?.Add(journalLine);

            // Business Partner
            BusinessPartner businessPartner = new BusinessPartner();
            //businessPartner.CardCode = journalDto.U_xWTVendor;
            businessPartner.CardName = journalDto.U_xSupplierName;
            businessPartner.CardType = journalDto.CardType;
            businessPartner.GroupNum = journalDto.GroupNum;
            businessPartner.WTLiable = journalDto.WTLiable;
            businessPartner.E_mail = journalDto.E_mail;
            businessPartner.Phone1 = journalDto.Phone1;
            businessPartner.CntctPrsn = journalDto.CntctPrsn;
            businessPartner.CreatedAt = createdAt;
            businessPartner.U_RefNum = journalDto.U_RefNum;

            await _unitOfWork.JournalEntry.AddAsync(journal);
            await _unitOfWork.BusinessPartner.AddAsync(businessPartner);
            await _unitOfWork.Save();

            return journal;
        }

        public async Task<JournalEntry?> GetStatusAsync(Guid id)
        {
            return await _unitOfWork.JournalEntry.GetStatusAsync(id);
        }
    }

}
