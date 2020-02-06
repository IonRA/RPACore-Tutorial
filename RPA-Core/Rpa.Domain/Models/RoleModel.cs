using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Rpa.Domain.Models
{
    public class RoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
