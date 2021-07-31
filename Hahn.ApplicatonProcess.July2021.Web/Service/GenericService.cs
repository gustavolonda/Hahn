using Hahn.ApplicatonProcess.July2021.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
namespace Hahn.ApplicatonProcess.July2021.Web.Service
{   
    public class GenericService<T> : IGenericService<T> where T : class
    {  /********************************************************
       *              Implements Generic Service             *
       *********************************************************/
       public IUnitOfWork _unitOfWork;
        // Init
        public GenericService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }   
        // Get By Id
        public virtual  Task<ResponseResult> GetById(object id)
        {
        
            throw  new NotImplementedException();
            
        }           
        // Insert     
        public virtual  Task<ResponseResult> Insert(T entity)
        {
            
             throw new NotImplementedException();
        }
        // Update Entity
        public virtual Task<ResponseResult> Update(T entityToUpdate, object idWhereUpdate)
        {
            throw new NotImplementedException();
        }  
        
        // Delete by Id
        public virtual Task<ResponseResult> Delete(object id)
        {
            throw new NotImplementedException();
        }
          
    }
}