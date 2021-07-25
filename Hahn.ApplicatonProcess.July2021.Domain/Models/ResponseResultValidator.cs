    using System;
    using System.Collections.Generic;
    namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
     /********************************************************
    *               Response Result Validator                *
    *********************************************************/
     public class ResponseResultValidator
    {                
        public bool IsError { get; set; }       
        public List<string> ErrorMessages { get; set; }   
        public ResponseResultValidator(){
            
            this.IsError       = false;      
            this.ErrorMessages = new List<string>();
        }    
    }


}
   