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
     public class AddressValidator: GenericValidator<Adress>
    {   
        public AddressValidator(){
            RuleFor(x=>x.PostatCode).Empty().WithMessage("Please specify a postcode");
            RuleFor(x=>x.Street).Empty().WithMessage("Please specify a street");
            RuleFor(x=>x.HouseNumber).MinimumLength(3).WithMessage("Please specify a house number");


        }
        // Check that the user exists Error

    }
 }