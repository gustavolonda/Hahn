using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Threading;
namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
    /********************************************************
    *                       Adress Model                     *
    *********************************************************/
     public class Adress
    {        
        public int Id { get; set; }            
        public string PostatCode { get; set; }       
        public string Street { get; set; }   
        public string HouseNumber { get; set; }  
        public Adress(){
            this.PostatCode  = "";      
            this.Street      = "";
            this.HouseNumber = "";

        }    
    }
    
}