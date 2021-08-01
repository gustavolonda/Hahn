    using System;
    using System.Collections.Generic;
    namespace Hahn.ApplicatonProcess.July2021.Domain.Models
{ 
     /********************************************************
    *               Response Result Validator                *
    *********************************************************/
     public class ResponseResult
    {                  
        public List<string> ErrorMessages { get; set; }   
        public string ResultStatus { get; set; }   
        public string ResultMessage { get; set;} 
        public object Response { get; set; }  
        public int StatusCode { get; set; }  

        public ResponseResult(){   
            this.ErrorMessages = new List<string>();
            this.ResultStatus  = "";
            this.ResultMessage = "";
            this.Response = "";
            this.StatusCode = 0;

        }    
    }


}
   