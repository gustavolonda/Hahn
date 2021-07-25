using System.ComponentModel.DataAnnotations;
using System;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{ 
    /********************************************************
    *                       User Validator                   *
    *********************************************************/
     public class UserValidator: AbstractValidator<User>
    {   
        public UserValidator(){
            RuleFor(x=>x.Age).GreaterThan(18).WithMessage("Must be over 18 years old");
            RuleFor(x=>x.FirstName).MinimumLength(3).WithMessage("At least 3 characters");
            RuleFor(x=>x.LastName).MinimumLength(3).WithMessage("At least 3 characters");
            RuleFor(x=>x.Email).EmailAddress().WithMessage("Invaded email");

        }
        // Check that the user exists Error
        public ResponseResultValidator UserCheckErrorExists(User user){
            var responseResultValidator = new ResponseResultValidator();
            var result = this.Validate(user);
            if(!result.IsValid){
                responseResultValidator.IsError = true;
                foreach(var error in result.Errors)
                    responseResultValidator.ErrorMessages.Add($"{error.PropertyName} : {error.ErrorMessage}");
            }


            return responseResultValidator;

        }

    }
 }