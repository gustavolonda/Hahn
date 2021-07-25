using System.ComponentModel.DataAnnotations;
using System;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{ 
    /********************************************************
    *                       Address Validator                   *
    *********************************************************/
     public class AddressValidator: GenericValidator<Address>
    {   
        public AddressValidator(){
            RuleFor(x=>x.PostatCode).NotEmpty().WithMessage("Please specify a postcode");
            RuleFor(x=>x.Street).NotEmpty().WithMessage("Please specify a street");
            RuleFor(x=>x.HouseNumber).NotEmpty().WithMessage("Please specify a house number");


        }

    }
 }