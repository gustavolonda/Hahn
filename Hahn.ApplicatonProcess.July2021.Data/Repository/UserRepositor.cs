using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using  Hahn.ApplicatonProcess.July2021.Data.Repository;
using  Hahn.ApplicatonProcess.July2021.Data.Models;
using  Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using  Hahn.ApplicatonProcess.July2021.Data.DataAccess;
namespace Hahn.ApplicatonProcess.July2021.Data.Core.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        /********************************************************
       *              Implements User Repository                *
       *********************************************************/
        public UserRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {
            
        }
        public override async Task<User> GetById(int id)
        {
             try
            {
                return await dbSet.FindAsync(id);
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex,  "{Repo} Upsert method error", typeof(UserRepository));
                return new User();
                
            }
            
        } 
        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                        .FirstOrDefaultAsync();

                if(existingUser == null)
                    return await Insert(entity);
                existingUser.Age       = entity.Age;
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName  = entity.LastName;
                existingUser.Address   = entity.Address;
                existingUser.Email     = entity.Email;
                existingUser.Assets    = entity.Assets;

                return true;
            }
            catch(Exception ex)
            {
                 this.logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                    .FirstOrDefaultAsync();

                if(exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }

                return false;     
            }
            catch(Exception ex)
            {
                 this.logger.LogError(ex, "{Repo} Delete method error", typeof(UserRepository));
                return false;
            }
        }
    }
}