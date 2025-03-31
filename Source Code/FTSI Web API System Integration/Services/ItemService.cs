using FTSI_Web_API_System_Integration.DTOs.Items;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.Items;

namespace FTSI_Web_API_System_Integration.Services
{
    public class ItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Item?> GetStatusAsync(Guid id)
        {
            return await _unitOfWork.Item.GetStatusAsync(id);
        }

        public async Task<Item> AddAsync(AddItemDTO dto)
        {
            DateTime createAt = DateTime.Now;

            Item item = new()
            {
                Series = dto.Series,
                // ItemCode = dto.ItemCode,
                U_ItemID = dto.U_ItemID,
                U_PackageID = dto.U_PackageID,
                U_ProcedureID = dto.U_ProcedureID,  
                ItemName = dto.ItemName,
                ItmsGrpCod = dto.ItmsGrpCod,
                UgpEntry = dto.UgpEntry,
                InvntItem = dto.InvntItem,
                SellItem = dto.SellItem,
                PrchseItem = dto.PrchseItem,
                DfltWH = dto.DfltWH,
                MngMethod = dto.MngMethod,
                BuyUnitMsr = dto.BuyUnitMsr,
                SalUnitMsr = dto.SalUnitMsr,
                InvntryUom = dto.InvntryUom,
                GLMethod = dto.GLMethod,
                U_CustTag = dto.U_CustTag,
                U_Package = dto.U_Package,
                U_RefNum = dto.U_RefNum,
                CreatedAt = createAt,
            };

            await _unitOfWork.Item.AddAsync(item);
            await _unitOfWork.Item.SaveChangesAsync();

            return item;
        }
    }
}