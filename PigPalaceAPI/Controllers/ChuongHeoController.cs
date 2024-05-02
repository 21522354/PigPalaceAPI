using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using PigPalaceAPI.Repository.ChuongHeoRepo;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuongHeoController : ControllerBase
    {
        private readonly IChuongHeoRepository _chuongHeoRepository;
        private readonly IMapper _iMapper;

        public ChuongHeoController(IChuongHeoRepository chuongHeoRepository, IMapper iMapper)
        {
            _chuongHeoRepository = chuongHeoRepository;
            _iMapper = iMapper;
        }

        [HttpGet("GetAllChuongHeo")]
        public async Task<ActionResult<List<CHUONGHEO>>> GetAllChuongHeo()
        {
            var listChuongHeo = await _chuongHeoRepository.GetAllChuongHeo();
            return Ok(listChuongHeo);
        }

        [HttpGet("GetChuongHeoByID/{id}")]
        public async Task<ActionResult<CHUONGHEO>> GetChuongHeoById(Guid id)
        {
            var chuongHeo = await _chuongHeoRepository.GetChuongHeoById(id);
            if (chuongHeo == null)
            {
                return NotFound();
            }
            return Ok(chuongHeo);
        }

        [HttpPost("CreateChuongHeo")]
        public async Task<ActionResult<string>> CreateChuongHeo(ChuongHeoModel chuongHeoModel)
        {
            var chuongHeo = _iMapper.Map<CHUONGHEO>(chuongHeoModel);
            chuongHeo.MaChuong = Guid.NewGuid();
            var result = await _chuongHeoRepository.CreateChuongHeo(chuongHeo);
            if (result == "Farm not found")
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("UpdateChuongHeo")]
        public async Task<ActionResult<string>> UpdateChuongHeo(CHUONGHEO chuongHeo)
        {
            try
            {
                var result = await _chuongHeoRepository.UpdateChuongHeo(chuongHeo);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest("Can't change the ChuongHeoId");
            }
        }

        [HttpDelete("DeleteChuongHeoByID/{id}")]
        public async Task<ActionResult<string>> DeleteChuongHeo(Guid id)
        {
            try
            {
                var result = await _chuongHeoRepository.DeleteChuongHeo(id);
                return Ok(result);
            }
            catch
            {
                return BadRequest("Can't delete this ChuongHeo");
            }
        }
    }
}
