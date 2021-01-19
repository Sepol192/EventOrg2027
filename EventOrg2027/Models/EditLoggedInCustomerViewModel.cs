using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventOrg2027.Models
{
    public class EditLoggedInCustomerViewModel
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        public string Email { get; set; }
    }
}
