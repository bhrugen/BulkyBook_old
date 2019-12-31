using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BulkyBook.Models
{
    public class CoverType
    {
        [Key]
        public int Id { get; set; }

        [Display(Name= "Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
