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
    *                       Asset Model                      *
    *********************************************************/
     public class Asset
    {        
        public int Id { get; set; }            
        public string Symbol { get; set; }       
        public string Name { get; set; }   
        public static int globalAssetID;
        public Asset(){
            
            this.Id     = Interlocked.Increment(ref globalAssetID);
            this.Symbol = "";      
            this.Name   = "";

        }    
    }
    
}