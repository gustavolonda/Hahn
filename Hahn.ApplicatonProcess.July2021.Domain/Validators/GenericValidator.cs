
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
       public ResponseResultValidator CheckErrorExists(T obj, AbstractValidator<T> validator){
           var responseResultValidator = new ResponseResultValidator();
            var result = validator.Validate(obj);
            if(!result.IsValid){
                responseResultValidator.IsError = true;
                foreach(var error in result.Errors)
                    responseResultValidator.ErrorMessages.Add($"{error.ErrorMessage}");
            }
            return responseResultValidator;

       }
    }
}