using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.Dto.PayDto;
using InsuranceOffer.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _payService;

        public PayController(IPayService payService)
        {
            _payService = payService;
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _payService.Get(p => p.PayID == id);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.PayeById });
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _payService.GetList();
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.PayListFetched });
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add([FromBody] AddPayDto addPayDto)
        {

            var pay = new Pay
            {
                PolicyID = addPayDto.PolicyID,
                InsuredID = addPayDto.InsuredID,
                KartNo = addPayDto.KartNo,
                ExpirationDate = addPayDto.ExpirationDate,
                CVC = addPayDto.CVC
            };

            var result = _payService.Add(pay);
            if (result.Success)
            {
                return Ok(new { Data = pay, Message = Messages.PayAdded });
            }

            return BadRequest(result.Message);
        }

    }
}
