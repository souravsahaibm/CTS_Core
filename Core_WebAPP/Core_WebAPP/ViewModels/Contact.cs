using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core_WebAPP.ViewModels
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Input string is too longer")]
        [MinLength(3)]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
    }
}
