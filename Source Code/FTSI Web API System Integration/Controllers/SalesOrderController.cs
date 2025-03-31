using FTSI_Web_API_System_Integration.DTOs;
using FTSI_Web_API_System_Integration.DTOs.ARInvoice;
using FTSI_Web_API_System_Integration.DTOs.SalesOrder;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.ARInvoice;
using FTSI_Web_API_System_Integration.Models.BusinessObjects.SalesOrder;
using FTSI_Web_API_System_Integration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FTSI_Web_API_System_Integration.Controllers
{
    [Route("api/documents/sales-order")]
    [ApiController]
    [Authorize]
    public class SalesOrderController : ControllerBase
    {
        private readonly SalesOrderService _service;

        public SalesOrderController(SalesOrderService service)
        {
            _service = service;
        }

        [HttpPost("item")]
        public async Task<ActionResult<PostResponse>> PostItemDocument([FromBody] SalesOrderItemHeaderDTO dto)
        {
            SalesOrderHeader header;

            try
            {
                header = await _service.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = dto.U_RefNum ?? "" } });
            }

            return Ok(new PostResponse { Status = "Success", Message = "Successfully Saved.", Data = new PostResponseData { Id = header.Id, U_RefNum = header.U_RefNum ?? "" } });
        }

        [HttpPost("service")]
        public async Task<ActionResult<PostResponse>> PostServiceDocument([FromBody] SalesOrderServiceHeaderDTO dto)
        {
            SalesOrderHeader header;

            try
            {
                header = await _service.AddAsync(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new PostResponse { Status = "Error", Message = ex.Message, Data = new PostResponseData { U_RefNum = dto.U_RefNum ?? "" } });
            }

            return Ok(new PostResponse { Status = "Success", Message = "Successfully Saved.", Data = new PostResponseData { Id = header.Id, U_RefNum = header.U_RefNum ?? "" } });
        }

        [HttpGet("status/{id}")]
        public async Task<ActionResult<GetResponse>> GetStatus(Guid id)
        {

            SalesOrderHeader header = new SalesOrderHeader();
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
