﻿using AutoMapper;
using PigPalaceAPI.Data.Entity;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Utilities
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<CHUONGHEO, ChuongHeoModel>().ReverseMap();
            CreateMap<LOAIHEO, LoaiHeoModel>().ReverseMap();    
            CreateMap<GIONGHEO, GiongHeoModel>().ReverseMap();   
            CreateMap<HEO, HeoModel>().ReverseMap(); 
            CreateMap<HEO, HeoModel2>().ReverseMap();       
        }
    }
}
