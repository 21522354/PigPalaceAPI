using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Data.Entity;

namespace PigPalaceAPI.Repository.ChuongHeoRepo
{
    public class ChuongHeoRepository : IChuongHeoRepository
    {
        private readonly PigPalaceDBContext _context;

        public ChuongHeoRepository(PigPalaceDBContext context)
        {
            _context = context;
        }
        public async Task<string> CreateChuongHeo(CHUONGHEO chuongHeo)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == chuongHeo.FarmID);  
            if (farm == null)
            {
                return "Farm not found";
            }
            await _context.CHUONGHEOs.AddAsync(chuongHeo);      
            await _context.SaveChangesAsync();  
            return "ChuongHeo created successfully";    
        }

        public async Task<string> DeleteChuongHeo(Guid id)
        {
            var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == id);    
            if (chuongHeo == null)
            {
                return "ChuongHeo not found";
            }
            _context.CHUONGHEOs.Remove(chuongHeo);      
            await _context.SaveChangesAsync();  
            return "ChuongHeo deleted successfully";        
        }

        public Task<List<CHUONGHEO>> GetAllChuongHeo()
        {
            var listChuongHeo = _context.CHUONGHEOs.ToListAsync();      
            return listChuongHeo;   
        }

        public async Task<CHUONGHEO> GetChuongHeoById(Guid id)
        {
            var chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == id);
            return chuongHeo;   
        }

        public async Task<string> UpdateChuongHeo(CHUONGHEO chuongHeo)
        {
            var _chuongHeo = await _context.CHUONGHEOs.FirstOrDefaultAsync(x => x.MaChuong == chuongHeo.MaChuong);
            if (_chuongHeo == null)
            {
                return "ChuongHeo not found";
            }
            _context.Entry(_chuongHeo).CurrentValues.SetValues(chuongHeo);
            _context.CHUONGHEOs.Update(_chuongHeo);
            await _context.SaveChangesAsync();
            return "Update Successfully";  
        }
    }
}
