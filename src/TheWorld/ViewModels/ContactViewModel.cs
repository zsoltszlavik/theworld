using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class ContactViewModel
    {
        [Required] //this a data annnotation
        [StringLength(255, MinimumLength = 5)] //this a data annnotation
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(1044, MinimumLength = 5)] //We can share these validation info with the client to do client side validation based on this
        public string Message { get; set; }
    }
}

