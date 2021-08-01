using System.ComponentModel.DataAnnotations;

namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public AuthenticateRequest(){
            this.Username  = "";
            this.Password  = "";

        }
    }
}