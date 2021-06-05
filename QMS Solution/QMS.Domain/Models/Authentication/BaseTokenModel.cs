using System.ComponentModel.DataAnnotations;

namespace QMS.Domain.Models.Authentication
{
    public class BaseTokenModel
    {
        [Required]
        public string Token { get; set; }
    }
}
