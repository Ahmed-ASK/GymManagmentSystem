﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.ViewModels.MemberViewModel
{
    public class HealthRecordViewModel
    {
        [Required(ErrorMessage = "Hight Is Required")]
        [Range(0.1,300,ErrorMessage = " Height Must Be Greated Than 0 And Less Than 300")]
        public decimal Hight { get; set; }

        [Required(ErrorMessage = "Weight Is Required")]
        [Range(0.1, 500, ErrorMessage = " Height Must Be Greated Than 0 And Less Than 500")]
        public decimal Weight { get; set; }

        [Required(ErrorMessage = "BloodType Is Required")]
        [StringLength(3 , ErrorMessage = "Blood Type Must Be 3 Char Or Less")]
        public string BloodType { get; set; } = null!;

        public string? Note{ get; set; }
    }
}
