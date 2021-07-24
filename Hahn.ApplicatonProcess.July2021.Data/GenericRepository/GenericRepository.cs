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

namespace Hahn.ApplicatonProcess.July2021.Data.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {  /********************************************************
       *              Implements Generic Repository             *
       *********************************************************/
        internal AppDbContext context;
        protected readonly ILogger logger;
        internal DbSet<T> dbSet;
        // Init
        public GenericRepository(AppDbContext context, ILogger logger)
        {
            this.context = context;
            this.logger  = logger;
            this.dbSet   = context.Set<T>();
        }   
        // Get ALL     
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
        // Get By Id
        public virtual async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }           
        // Insert     
        public virtual async Task<bool> Insert(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        // Delete by Id
        public virtual Task<bool> Delete(object id)
        {
            throw new NotImplementedException();
        }
    
        // Update Entity
        public virtual Task<bool> Update(T entityToUpdate)
        {
            throw new NotImplementedException();
        }        
    }
}