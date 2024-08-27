using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Dto.AssuranceDto;
using InsuranceOffer.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuranceController : ControllerBase
    {
        private readonly IAssuranceService _assuranceService;

        public AssuranceController(IAssuranceService assuranceService)
        {
            _assuranceService = assuranceService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _assuranceService.GetAll();

            if (result.Success)
            {
                // DTO'ya göre verileri dönüyoruz
                var data = result.Data.Select(a => new ListAssuranceDto
                {
                    AssuranceCode = a.AssuranceCode,
                    Title = a.Title,
                    Description = a.Description,
                    Price = a.Price,
                    isRequired = a.isRequired
                }).ToList();

                return Ok(new { Data = data, Message = Messages.AssuranceList });
            }

            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(Guid assuranceId)
        {
            var result = _assuranceService.GetById(assuranceId);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.AssuranceById });
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] AddAssuranceDto dto)
        {
           
            var assurance = new Assurance
            {
                AssuranceCode = dto.AssuranceCode,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                isRequired = dto.isRequired
            };

            var result = _assuranceService.Add(assurance);
            if (result.Success)
            {
                return Ok(new { Data = assurance, Message = Messages.AssuranceAdded });
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Guid id, [FromBody] UpdateAssuranceDto dto)
        {
            if (id != dto.AssuranceCode)
            {
                return BadRequest("Teminat uyuşmadı");
            }

            // Map UpdateAssuranceDto to Assurance
            var assurance = new Assurance
            {
                AssuranceCode = dto.AssuranceCode,
                Title = dto.Title,
                Description = dto.Description,
                Price = dto.Price,
                isRequired = dto.isRequired
            };

            var result = _assuranceService.Update(assurance);
            if (result.Success)
            {
                return Ok(new { Data = assurance, Message = Messages.AssuranceUpdated });
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _assuranceService.GetById(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound("Teminat bulunamadı.");
            }

            var assurance = result.Data;
            var deleteResult = _assuranceService.Delete(assurance);
            if (deleteResult.Success)
            {
                return Ok(new { Data = assurance, Message = Messages.AssuranceDeleted });
            }
            return BadRequest(deleteResult.Message);
        }
    }
}
