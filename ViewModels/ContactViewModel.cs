using System.ComponentModel.DataAnnotations;

namespace DutchTreat.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }

    }
}
