using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Dto.VerificationDto;
using InsuranceOffer.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly IVerificationCodesService _verificationCodesService;

        public VerificationController(IVerificationCodesService verificationCodesService)
        {
            _verificationCodesService = verificationCodesService;
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] VerificationCodeDto verificationCodeDto)
        {
            if (verificationCodeDto == null || string.IsNullOrEmpty(verificationCodeDto.Code))
            {
                return BadRequest("Invalid verification code data.");
            }

            var result = _verificationCodesService.GetByCode(verificationCodeDto.Code);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Success = true, Message = Messages.AssuranceAdded });
            }
            return BadRequest(new { Success = false, Message = result.Message });
        }
    }

  
}
