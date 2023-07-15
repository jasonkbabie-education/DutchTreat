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
        [MaxLength(100, ErrorMessage = "This message is too long. It needs to be 100 characters max")]
        public string Message { get; set; }

    }
}
