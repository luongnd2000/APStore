﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class UserLogin
    {
        [Required(ErrorMessage = "Không được để trống tên đăng nhập")]
        [RegularExpression(@"^\S*$", ErrorMessage = "Không được có khoảng trống trong tên đăng nhập")]
        [DisplayName("Tên đăng nhập")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Không được để trống mật khẩu")]
        [DisplayName("Mật khẩu")]
        public string Pass { get; set; }
        [DisplayName("Tên")]
        public string NameDisplay { get; set; }
        public string AvartarPath { get; set; }
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail Không hợp lệ")]
        public string Email { get; set; }
    }
}
