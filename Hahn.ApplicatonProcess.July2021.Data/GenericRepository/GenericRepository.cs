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
             try
            {
                return await dbSet.ToListAsync();
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex, "{Repo}Repository Upsert method error", typeof(T));
                return new List<T>();
            }
        }
        // Get By Id
        public virtual async Task<T> GetById(int id)
        {
       
                return await dbSet.FindAsync(id);
            
        }           
        // Insert     
        public virtual async Task<bool> Insert(T entity)
        {
            
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex, "{Repo}Repository Upsert method error", typeof(T));
                return false;
                
            }
        }
        // Delete by Id
        public virtual Task<bool> Delete(int id)
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