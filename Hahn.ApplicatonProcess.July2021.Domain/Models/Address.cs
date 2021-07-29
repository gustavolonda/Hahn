using System.Data;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
    /********************************************************
    *                       Address Model                     *
    *********************************************************/
     public class Address
    {   
        [Key]     
        public int Id { get; set; }            
        public string PostatCode { get; set; }       
        public string Street { get; set; }   
        public string HouseNumber { get; set; }


        public Address(){
            this.PostatCode  = "";      
            this.Street      = "";
            this.HouseNumber = "";
     

        }    
    }
    
}