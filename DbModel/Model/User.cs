using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DbModel.Model
{
    public class User
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        [MaxLength(50), MinLength(3)]
        public string Name { get; set; }
        
        [Required]
        public string JobTitle { get; set; }
        
        [Required]
        [MaxLength(3), MinLength(1), Range(1, 100)]
        public int Age { get; set; }
        
        [Required]
        public DateTime EmpStartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<DateTime> EmpEndDate { get; set; }


    }
}
