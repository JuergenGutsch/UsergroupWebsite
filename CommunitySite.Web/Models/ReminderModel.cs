using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommunitySite.Web.Models
{
    public class ReminderModel
    {
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "Bitte eine gültige E-Mailadresse angeben.")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        public string Error { get; set; }

        public bool Success { get; set; }
    }
}