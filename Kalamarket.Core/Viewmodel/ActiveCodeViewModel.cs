using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _98market.Core.Viewmodel
{
    public class ActiveCodeViewModel
    {
        public string Mobile { get; set; }
        [Required(ErrorMessage = "لطفا کد فعالسازی را وارد کنید")]
        [Display(Name = "کد فعالسازی")]
        public string ActiveCode { get; set; }
    }

   
}
