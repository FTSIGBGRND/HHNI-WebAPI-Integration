﻿using FTSI_Web_API_System_Integration.DTOs.IncomingPayment;
using FTSI_Web_API_System_Integration.DTOs;
using FTSI_Web_API_System_Integration.DTOs.Items;
using FTSI_Web_API_System_Integration.Interfaces;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.IncomingPayment;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.Items;
using FTSI_Web_API_System_Integration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesBOM;

namespace FTSI_Web_API_System_Integration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesBomController : ControllerBase
    {
        private readonly SalesBomService _service;

        public SalesBomController(SalesBomService service)
        {
            _service = service;
        }
                
        [HttpPost]
        public async Task<ActionResult<PostResponse>> PostItem([FromBody] AddProductTreeDTO dto)
        {
            ProductTree productTree;

            try
            {
                productTree = await _service.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = dto.U_RefNum ?? "" } });
            }

            return Ok(new PostResponse { Status = "Success", Message = "Successfully Saved.", Data = new PostResponseData { Id = productTree.Id, U_RefNum = productTree.U_RefNum ?? "" } });
        }

        [HttpGet("status/{id}")]
        public async Task<ActionResult<GetResponse>> GetStatus(Guid id)
        {

            ProductTree? header = new ProductTree();
            string integStatus = string.Empty;

            try
            {
                header = await _service.GetStatusAsync(id);

                if (header == null)
                {
                    return NotFound(new GetResponse { Status = "Error", Message = $"Id [{id}] Not Found.", Data = new GetResponseData { Id = id } });
                }

                switch (header.IntegrationStatus)
                {
                    case 'P':
                        integStatus = "Pending";
                        break;
                    case 'E':
                        integStatus = "Error";
                        break;
                    case 'S':
                        integStatus = "Success";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = header.U_RefNum, Id = id } });
            }

            return Ok(new GetResponse { Status = "Success", Message = "Integration Status Successfully Retrieved.", Data = new GetResponseData { IntegrationStatus = integStatus, IntegrationMessage = header.IntegrationMessage ?? "", U_RefNum = header.U_RefNum ?? "", Id = id } });
        }
    }
}
