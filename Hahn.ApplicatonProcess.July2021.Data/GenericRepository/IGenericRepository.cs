using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Hahn.ApplicatonProcess.July2021.Data.GenericRepository
{
    /********************************************************
    *              Interface Generic Repository             *
    *********************************************************/
    public interface IGenericRepository<TEntity> where TEntity : class
    {        
        IEnumerable<TEntity> GetAll();
        TEntity GetById(object id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(object obj);        
    }
}