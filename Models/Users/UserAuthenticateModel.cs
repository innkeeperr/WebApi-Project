using System.ComponentModel.DataAnnotations;

/*
 * Defines parameters for incoming POST request
 */
namespace WebApi.Models.Users
{
    public class UserAuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}