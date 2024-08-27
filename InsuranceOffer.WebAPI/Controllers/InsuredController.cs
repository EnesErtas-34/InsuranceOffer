//using InsuranceOffer.BusinessLayer.Abstract;
//using InsuranceOffer.BusinessLayer.Contants;
//using InsuranceOffer.EntityLayer.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace InsuranceOffer.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InsuredController : ControllerBase
//    {
//        private readonly IInsuredService _insuredService;

//        public InsuredController(IInsuredService insuredService)
//        {
//            _insuredService = insuredService;
//        }
//        [HttpGet("getall")]
//        public IActionResult GetList()
//        {
//            var result = _insuredService.GetAll();
//            if (result.Success)
//            {
//                return Ok(new { Data = result.Data, Message = Messages.InsuredList });
//            }
//            return BadRequest(result.Message);
//        }
//        [HttpGet("getlistbyTC")]
//        public IActionResult GetListByTc(string tc)
//        {
//            var result = _insuredService.GetByTC(tc);
//            if (result.Success)
//            {
//                return Ok(new { Data = result.Data, Message = Messages.InsuredByTc });
//            }
//            return BadRequest(result.Message);
//        }
//        [HttpGet("getbyid")]
//        public IActionResult GetById(int insuredId)
//        {
//            var result = _insuredService.GetById(insuredId);
//            if (result.Success)
//            {
//                return Ok(new { Data = result.Data, Message = Messages.InsuredById });
//            }
//            return BadRequest(result.Message);
//        }
//        [HttpPost("add")]
//        public IActionResult Add(Insured insured)
//        {
//            var result = _insuredService.Add(insured);
//            if (result.Success)
//            {
//               return Ok(new { Data = insured, Message = Messages.InsuredAdded });
//            }
//            return BadRequest(result.Message);
//        }
//        [HttpPut("update")]
//        public IActionResult Update(int id, [FromBody] Insured insured)
//        {

//            if (id != insured.InsuredID)
//            {
//                return BadRequest("Müşteri uyuşmadı");
//            }

//            var result = _insuredService.Update(insured);
//            if (result.Success)
//            {
//                return Ok(new { Data = insured, Message = Messages.InsuredUpdated });
//            }
//            return BadRequest(result.Message);
//        }
//        [HttpDelete("delete/{id}")]
//        public IActionResult Delete(int id)
//        {
//            var result = _insuredService.GetById(id);
//            if (!result.Success || result.Data == null)
//            {
//                return NotFound("Müşteri bulunamadı.");
//            }

//            var insured = result.Data;
//            var deleteResult = _insuredService.Delete(insured);
//            if (deleteResult.Success)
//            {
//                return Ok(new { Data = insured, Message = Messages.InsuredDeleted });
//            }
//            return BadRequest(deleteResult.Message);
//        }
//    }
//}
////asil kod burada başlıyor
//using InsuranceOffer.BusinessLayer.Abstract;
//using InsuranceOffer.BusinessLayer.Contants;
//using InsuranceOffer.Dto.InsuredDto;
//using InsuranceOffer.EntityLayer.Concrete;
//using Microsoft.AspNetCore.Mvc;


//namespace InsuranceOffer.WebAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InsuredController : ControllerBase
//    {
//        private readonly IInsuredService _insuredService;

//        public InsuredController(IInsuredService insuredService)
//        {
//            _insuredService = insuredService;

//        }

//        [HttpGet("getall")]
//        public IActionResult GetList()
//        {
//            var result = _insuredService.GetAll();
//            if (result.Success)
//            {
//                return Ok(new { Data = result.Data, Message = Messages.InsuredList });
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("getlistbyTC")]
//        public IActionResult GetListByTc(string tc)
//        {
//            var result = _insuredService.GetByTC(tc);
//            if (result.Success)
//            {
//                return Ok(new { Data = result.Data, Message = Messages.InsuredByTc });
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpGet("getbyid")]
//        public IActionResult GetById(int insuredId)
//        {
//            var result = _insuredService.GetById(insuredId);
//            if (result.Success)
//            {
//                return Ok(new { Data = result.Data, Message = Messages.InsuredById });
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpPost("add")]
//        public IActionResult Add(AddInsuredDto addInsuredDto)
//        {
//            Insured insured = new Insured()
//            {
//                TC = addInsuredDto.TC,
//                BirthDate = addInsuredDto.BirthDate,
//                Email = addInsuredDto.Email,
//                Number = addInsuredDto.Number
//            };
//            //VerificationCodes verification = new VerificationCodes()
//            //{
//            //    PhoneNumber = addInsuredDto.Number,
//            //    Code = "123456"
//            //};
//            var result = _insuredService.Add(insured);
//            ////buradaki dönen değeri değişkene al kontrolünü yap 
//            //var result1= _verificationCodesService.Add(verification);
//            //if (result1)
//            //{
//            //    return Ok();
//            //    //burada sms service çağır
//            //}

//            if (result.Success)
//            {
//                return Ok(new { Data = insured, Message = Messages.InsuredAdded });
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpPut("update")]
//        public IActionResult Update(int id, [FromBody] UpdateInsuredDto updateInsuredDto)
//        {

//            if (id != updateInsuredDto.InsuredID)
//            {
//                return BadRequest("Müşteri uyuşmadı");
//            }
//            Insured insured = new Insured()
//            {
//                InsuredID = updateInsuredDto.InsuredID,
//                TC = updateInsuredDto.TC,
//                BirthDate = updateInsuredDto.BirthDate,
//                Email = updateInsuredDto.Email,
//                Number = updateInsuredDto.Number
//            };

//            var result = _insuredService.Update(insured);
//            if (result.Success)
//            {
//                return Ok(new { Data = insured, Message = Messages.InsuredUpdated });
//            }
//            return BadRequest(result.Message);
//        }

//        [HttpDelete("delete/{id}")]
//        public IActionResult Delete(int id)
//        {
//            var result = _insuredService.GetById(id);
//            if (!result.Success || result.Data == null)
//            {
//                return NotFound("Müşteri bulunamadı.");
//            }

//            var insured = result.Data;
//            var deleteResult = _insuredService.Delete(insured);
//            if (deleteResult.Success)
//            {
//                return Ok(new { Data = insured, Message = Messages.InsuredDeleted });
//            }
//            return BadRequest(deleteResult.Message);
//        }
//    }
//}

using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Dto.InsuredDto;
using InsuranceOffer.EntityLayer.Concrete;
using InsuranceOffer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuredController : ControllerBase
    {
        private readonly IInsuredService _insuredService;
        private readonly IVerificationCodesService _verificationCodesService;
        private readonly ISmsService _smsService;

        public InsuredController(IInsuredService insuredService, IVerificationCodesService verificationCodesService, ISmsService smsService)
        {
            _insuredService = insuredService;
            _verificationCodesService = verificationCodesService;
            _smsService = smsService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _insuredService.GetAll();
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.InsuredList });
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbyTC")]
        public IActionResult GetListByTc(string tc)
        {
            var result = _insuredService.GetByTC(tc);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.InsuredByTc });
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int insuredId)
        {
            var result = _insuredService.GetById(insuredId);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.InsuredById });
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddInsuredDto addInsuredDto)
        {
            try
            {
                Insured insured = new Insured()
                {
                    TC = addInsuredDto.TC,
                    BirthDate = addInsuredDto.BirthDate,
                    Email = addInsuredDto.Email,
                    Number = addInsuredDto.Number
                };

                var insuredResult = _insuredService.Add(insured);
                if (!insuredResult.Success)
                {
                    return BadRequest(insuredResult.Message);
                }

                VerificationCodes verification = new VerificationCodes()
                {
                    PhoneNumber = addInsuredDto.Number,
                    Code = GenerateVerificationCode(),
                    Expiration = DateTime.UtcNow.AddMinutes(2)
                };

                var verificationResult = _verificationCodesService.Add(verification);
                if (!verificationResult.Success)
                {
                    return BadRequest(verificationResult.Message);
                }

                await _smsService.SendSmsAsync(verification.PhoneNumber, verification.Code);
                return Ok(new { insuredID = insured.InsuredID });
                //return Ok(new { Data = insured, Message = Messages.InsuredAdded });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
