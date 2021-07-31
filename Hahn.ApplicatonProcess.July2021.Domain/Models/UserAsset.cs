using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
    /********************************************************
    *                  User Asset Model                     *
    *********************************************************/
     public class UserAsset
    {        
        public int UserId { get; set; }     
        [JsonIgnore] 
        public virtual User User { get; set; }        
        public string AssetId { get; set; } 
        public virtual Asset Asset { get; set; }
        public UserAsset(){
            this.UserId  = 0 ;
            this.User    = new User();      
            this.AssetId = "";
            this.Asset   = new Asset();



        }    
    }
    
}