using PigPalaceAPI.Data.Entity;

namespace PigPalaceAPI.Repository.ChuongHeoRepo
{
    public interface IChuongHeoRepository
    {
        public Task<List<CHUONGHEO>> GetAllChuongHeo();
        public Task<CHUONGHEO> GetChuongHeoById(Guid id);
        public Task<string> CreateChuongHeo(CHUONGHEO chuongHeo);
        public Task<string> UpdateChuongHeo(CHUONGHEO chuongHeo);
        public Task<string> DeleteChuongHeo(Guid id);
    }
}
