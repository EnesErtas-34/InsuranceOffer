using InsuranceOffer.BusinessLayer.Abstract;
using InsuranceOffer.BusinessLayer.Contants;
using InsuranceOffer.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceOffer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliceAssuranceController : ControllerBase
    {
        private readonly IPoliceAssuranceService _policeAssuranceService;

        public PoliceAssuranceController(IPoliceAssuranceService policeAssuranceService)
        {
            _policeAssuranceService = policeAssuranceService;
        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _policeAssuranceService.GetAll();
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.PoliceAssuranceList });
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int policeAssuranceId)
        {
            var result = _policeAssuranceService.GetById(policeAssuranceId);
            if (result.Success)
            {
                return Ok(new { Data = result.Data, Message = Messages.PoliceAssuranceById });
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(PoliceAssurance policeAssurance)
        {
            var result = _policeAssuranceService.Add(policeAssurance);
            if (result.Success)
            {
                return Ok(new { Data = policeAssurance, Message = Messages.PoliceAssuranceAdded });
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(int id, [FromBody] PoliceAssurance policeAssurance)
        {

            if (id != policeAssurance.PoliceAssuranceID)
            {
                return BadRequest("Police Teminat uyuşmadı");
            }

            var result = _policeAssuranceService.Update(policeAssurance);
            if (result.Success)
            {
                return Ok(new { Data = policeAssurance, Message = Messages.PoliceAssuranceUpdated });
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _policeAssuranceService.GetById(id);
            if (!result.Success || result.Data == null)
            {
                return NotFound("Poliçe Teminat bulunamadı.");
            }

            var policeAssurance = result.Data;
            var deleteResult = _policeAssuranceService.Delete(policeAssurance);
            if (deleteResult.Success)
            {
                 return Ok(new { Data = policeAssurance, Message = Messages.PoliceAssuranceDeleted });
            }
            return BadRequest(deleteResult.Message);
        }
    }
}
