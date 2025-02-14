﻿using System.ComponentModel.DataAnnotations;

namespace PigPalaceAPI.Model
{
    public class UserModel
    {
        public Guid FarmID { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Sex { get; set; }
        public float CoefficientsSalary { get; set; }
        public string RoleName { get; set; }   
        // public string? RoleID { get; set; }
    }
}
