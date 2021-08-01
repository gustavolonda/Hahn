using System;
using System.Collections.Generic;


namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
    /********************************************************
    *                       Asset Model                      *
    *********************************************************/
     public class Asset
    {        
        public string Id { get; set; }            
        public string Symbol { get; set; }       
        public string Name { get; set; }   
        public  List<UserAsset> UserAssets { get; set; }
        public Asset(){
            this.Symbol = "";      
            this.Name   = "";
            this.UserAssets   = new List<UserAsset>();


        }    
    }
    
}