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
            CreateMap<GIONGHEO, GiongHeoModel>().ReverseMap();   
            CreateMap<HEO, HeoModel>().ReverseMap();       
            CreateMap<HOADONHANGHOA, HoaDonHangHoaModel>().ReverseMap();
            CreateMap<HOADONHANGHOA, HoaDonHangHoaModel2>().ReverseMap();
            CreateMap<LICHPHOIGIONG, LichPhoiGiongModel>().ReverseMap();
            CreateMap<LICHCHOAN, LichChoAnRespond>().ReverseMap();
        }
    }
}
