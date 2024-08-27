using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Dto.PoliceDto;
using InsuranceOffer.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _policyService.GetAll();
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.PolicyList });
            }
            return BadRequest(result.Message);
        }
       
        [HttpGet("getbyid")]
        public IActionResult GetById(int policyId)
        {
            var result = _policyService.GetById(policyId);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.PolicyById });
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(AddPoliceDto addPoliceDto)
        {
            var policy = new Policy
            {
                InsuredID = addPoliceDto.InsuredID,
                InsurerID = addPoliceDto.InsurerID,
                Price = addPoliceDto.Price,
                StartDate = addPoliceDto.StartDate,
                EndDate = addPoliceDto.EndDate,
                Offer = addPoliceDto.Offer
               
            };

            var result = _policyService.Add(policy);
            if (result.Success)
            {
                return Ok(new { Data = policy.PolicyID, Message = Messages.PolicyAdded });
               //    return Ok(new { Data = policy, Message = Messages.PolicyAdded });
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePoliceDto updatePoliceDto)
        {
            if (id != updatePoliceDto.PolicyID)
            {
                return BadRequest("Poliçeler uyuşmadı");
            }

            var policy = new Policy
            {
                PolicyID = updatePoliceDto.PolicyID,
                InsuredID = updatePoliceDto.InsuredID,
                InsurerID = updatePoliceDto.InsurerID,
                Price = updatePoliceDto.Price,
                StartDate = updatePoliceDto.StartDate,
                EndDate = updatePoliceDto.EndDate,
                Offer = updatePoliceDto.Offer
            };

            var result = _policyService.Update(policy);
            if (result.Success)
            {
                return Ok(new { Data = policy, Message = Messages.PolicyUpdated });
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _policyService.GetById(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound("Poliçe bulunamadı.");
            }

            var policy = result.Data;
            var deleteResult = _policyService.Delete(policy);
            if (deleteResult.Success)
            {
                return Ok(new { Data = policy, Message = Messages.PolicyDeleted });
            }
            return BadRequest(deleteResult.Message);
        }
    }
}
