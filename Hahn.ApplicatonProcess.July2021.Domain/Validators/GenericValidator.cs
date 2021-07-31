
using System;
using System.Collections.Generic;
using System.Data;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using FluentValidation;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    public class GenericValidator<T> : AbstractValidator<T>,IGenericValidator<T> where T : class
    {  /********************************************************
       *              Implements Generic Validator             *
       *********************************************************/
        // Check Exists Error
       public ResponseResult CheckErrorExists(T obj, AbstractValidator<T> validator){
           var responseResult = new ResponseResult();
            var result = validator.Validate(obj);
            if(!result.IsValid){
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                foreach(var error in result.Errors)
                    responseResult.ErrorMessages.Add($"{error.ErrorMessage}");
            }
            return responseResult;

       }
    }
}