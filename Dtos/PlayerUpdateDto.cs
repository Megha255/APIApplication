
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Dtos
{
    public class PlayerUpdateDto
    {
       

        [Required]
        public String Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public String Nationality { get; set; }

        [Required]
        public String Status { get; set; }
    }
}
