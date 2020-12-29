using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Fashion.Models
{
    public class CreateRole
    {
        [Required]
        [Display(Name = "Role name")]
        [MaxLength(256)]
        public string RoleName { get; set; }
    }
}
