using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hahn.ApplicatonProcess.July2021.Data.Models
{ 
    /********************************************************
    *                       User Model                      *
    *********************************************************/
     public class User
    {        
        public int Id { get; set; }        
        public int Age { get; set; }       
        public string FirstName { get; set; }       
        public string LastName { get; set; }       
        public string Address { get; set; }
        public string Email { get; set; }
    }
}

