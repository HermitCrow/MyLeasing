using System.ComponentModel.DataAnnotations;

namespace MyLeasing.Common
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
