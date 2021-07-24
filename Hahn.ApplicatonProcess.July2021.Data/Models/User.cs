using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

using System.Threading;

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
        public List<Asset> Assets { get; set; }
        public static int globalUserID;
        public User(){
            
            this.Id        = Interlocked.Increment(ref globalUserID);
            this.Age       = 0;
            this.FirstName = "";      
            this.LastName  = "";       
            this.Address   = "";
            this.Email     = "";
            this.Assets    = new List<Asset> ();
        }
    }
}

