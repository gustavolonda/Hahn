using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using Hahn.ApplicatonProcess.July2021.Domain.Models;

namespace Hahn.ApplicatonProcess.July2021.Web.Service
{
    /********************************************************
    *              Interface Generic Service                *
    *********************************************************/
    public interface IGenericService<T> where T : class
    {           
        Task<ResponseResult> GetById(object id);
        Task<ResponseResult> Insert(T obj);   
        Task<ResponseResult> Update(T obj, object idWhereUpdate);
        
        Task<ResponseResult> Delete(object id);     
    }
}