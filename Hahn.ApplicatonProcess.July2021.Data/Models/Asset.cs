using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hahn.ApplicatonProcess.July2021.Data.Models
{ 
    /********************************************************
    *                       Asset Model                      *
    *********************************************************/
     public class Asset
    {        
        public int Id { get; set; }            
        public string Symbol { get; set; }       
        public string Name { get; set; }       

    }
}