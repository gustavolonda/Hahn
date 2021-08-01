
using System;
namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }


        public AuthenticateResponse(){
            this.Id       = 0;
            this.FirstName = "";
            this.LastName = "";
            this.Username  = "";
            this.JwtToken  = "";

        }
    }
}