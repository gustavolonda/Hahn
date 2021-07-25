using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using FluentValidation;

namespace Hahn.ApplicatonProcess.July2021.Domain.Validators
{
    /********************************************************
    *              Interface Generic Validator              *
    *********************************************************/
    public interface IGenericValidator<T> where T : class
    {        
        ResponseResultValidator CheckErrorExists(T obj, AbstractValidator<T> validator);
    }
}