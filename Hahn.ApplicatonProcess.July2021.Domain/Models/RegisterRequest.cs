using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
    /********************************************************
    *                       User Model                      *
    *********************************************************/
     public class RegisterRequest
    {   
        public int Id { get; set; }     
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }   
        public int Age { get; set; }       
        public string FirstName { get; set; }       
        public string LastName { get; set; }    
        public int AddressId { get; set; }   
        public virtual  Address Address { get; set; }
        public string Email { get; set; }
        // Contructor
        public RegisterRequest(){
            
            this.Age       = 0;
            this.FirstName = "";      
            this.LastName  = "";       
            this.Address   = new Address();
            this.Email     = "";
        }
    }
}