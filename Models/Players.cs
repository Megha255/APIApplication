using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIApplication.Models
{
    public class Players
    {
            [Key]
            [Required]
            public int Id { get; set; }

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
