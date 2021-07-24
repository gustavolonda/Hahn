using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace Hahn.ApplicatonProcess.July2021.Data.GenericRepository
{
    /********************************************************
    *              Interface Generic Repository             *
    *********************************************************/
    public interface IGenericRepository<T> where T : class
    {        
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        Task<bool> Insert(T obj);
        Task<bool> Update(T obj);
        Task<bool> Delete(object obj);        
    }
}