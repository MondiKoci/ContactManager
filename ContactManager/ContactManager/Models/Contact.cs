using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }
        
        public string Phone { get; set; }
        public string Portfolio { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Range(1, 10000, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Organization { get; set; }

        public string Slug => FirstName?.Replace(" ", "-").ToLower() + "-" + LastName?.Replace(" ", "-").ToLower();
    }
}
