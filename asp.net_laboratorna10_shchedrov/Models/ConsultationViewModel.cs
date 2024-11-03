using System;
using System.ComponentModel.DataAnnotations;

namespace asp.net_laboratorna10_shchedrov.Models
{
    public class ConsultationViewModel
    {
        [Required(ErrorMessage = "Please enter your full name.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please choose a consultation date.")]
        [DataType(DataType.Date)]
        public DateTime? ConsultationDate { get; set; }

        [Required(ErrorMessage = "Please choose a product.")]
        public string Product { get; set; }
    }
}
