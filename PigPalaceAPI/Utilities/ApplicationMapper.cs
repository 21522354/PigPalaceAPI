using AutoMapper;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Utilities
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CHUONGHEO, ChuongHeoModel>().ReverseMap();
        }
    }
}
