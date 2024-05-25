using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;
using System.Text;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public ChucVuController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetAllChucVu")]
        public async Task<IActionResult> GetAllChucVu(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm Not Found");
            }
            var listChucVu = await _context.Roles.Where(x => x.FarmID == FarmID).ToListAsync();
            return Ok(listChucVu);  
        }
        [HttpPost("CreateChucVu")]
        public async Task<IActionResult> CreateChucVu(RolesModel rolesModel)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == rolesModel.FarmID);
            if (farm == null)
            {
                return NotFound("Farm Not Found");
            }
            var roles = _mapper.Map<Roles>(rolesModel);
            roles.RoleID = GenerateRandomString(10);
            _context.Roles.Add(roles);
            await _context.SaveChangesAsync();
            return Ok("Create Role Successfully");
        }


        public static string GenerateRandomString(int length)
        {
            const string prefix = "CV"; // Các ký tự đầu tiên cố định
            Random random = new Random();
            // Tạo một StringBuilder để xây dựng chuỗi
            StringBuilder stringBuilder = new StringBuilder(prefix);

            // Số lượng ký tự ngẫu nhiên cần tạo bổ sung sau ký tự đầu tiên
            int charactersToGenerate = length - prefix.Length;

            // Tạo các ký tự ngẫu nhiên
            for (int i = 0; i < charactersToGenerate; i++)
            {
                // Sinh một ký tự chữ cái ngẫu nhiên từ 'A' đến 'Z'
                char randomChar = (char)random.Next('A', 'Z' + 1);
                stringBuilder.Append(randomChar);
            }

            return stringBuilder.ToString();
        }
    }
}
