using FTSI_Web_API_System_Integration.DTOs.Capitalization;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARCreditMemo;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.AssetDocuments;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.Items;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol.Core.Types;

namespace FTSI_Web_API_System_Integration.Services
{
    public class FixedAssetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FixedAssetService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<AssetDocument> AddFixedAssetAsync(AddFixedAssetDTO asset)
        {
            DateTime createdAt = DateTime.Now;

            // Items
            Item item = new Item();
            //item.ItemCode = asset.ItemCode;
            item.ItemName = asset.ItemName;
            item.AssetClass = asset.AssetClass;
            item.U_AssRes = asset.U_AssRes;
            item.U_Contract = asset.U_Contract;
            item.CreatedAt = createdAt;
            item.U_RefNum = asset.U_RefNum;
            item.DepreciationParameters?.Add(new DepreciationParameters
            {
                ItemCode = asset.ItemCode,
                DprStart = asset.DprStart,
                VisOrder = 0,
                UsefulLife = asset.UsefulLife,
                CreatedAt = createdAt,
            });


            // Capitalization

            AssetDocument assetDoc = new AssetDocument();
            assetDoc.CreatedAt = createdAt;
            assetDoc.PostDate = asset.PostDate;
            assetDoc.U_RefNum = asset.U_RefNum;

            assetDoc.AssetDocumentLines.Add(
                new AssetDocumentLine
                {
                    ItemCode = asset.ItemCode,
                    Quantity = asset.Quantity,
                    LineNum = 0,
                    LineTotal = asset.LineTotal,
                });


            await _unitOfWork.Item.AddAsync(item);
            await _unitOfWork.Capitalization.AddAsync(assetDoc);
            await _unitOfWork.Save();

            return assetDoc;
        }

        public async Task<AssetDocument?> GetStatusAsync(Guid id)
        {
            return await _unitOfWork.Capitalization.GetStatusAsync(id);
        }
    }

}
