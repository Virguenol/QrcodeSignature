using System.ComponentModel.DataAnnotations;

namespace Grs.BioRestock.Transfer.Requests.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}