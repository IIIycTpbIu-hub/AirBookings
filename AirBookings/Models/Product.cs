﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBookings.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название услуги")]
        [Required(ErrorMessage ="Вам необходимо заполнить поле Название услуги")]
        [RegularExpression(@"[^0-9]", ErrorMessage = "любые симовлы кроме цифр")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки должна быть от 2 до 50 символов")]
        public string ProductName { get; set; }
        [Display(Name = "Стоимость")]
        [Required]
        [Range(0, 10000, ErrorMessage = "слишком большая стоимость услуги")]
        public decimal Cost { get; set; }
        [Column("Employee_Id")]
        [Display(Name = "Исполнитель")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}