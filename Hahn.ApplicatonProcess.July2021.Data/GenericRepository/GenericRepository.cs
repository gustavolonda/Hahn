using Hahn.ApplicatonProcess.July2021.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Hahn.ApplicatonProcess.July2021.Data.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {  /********************************************************
       *              Implements Generic Repository             *
       *********************************************************/
        internal AppDbContext context;
        internal DbSet<TEntity> dbSet;
        // Init
        public GenericRepository(AppDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }   
        // Get ALL     
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        // Get By Id
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }           
        // Insert     
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        // Delete by Id
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        // Delete by Entity
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        // Update Entity
        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }        
    }
}