using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using  Hahn.ApplicatonProcess.July2021.Data.Repository;
using  Hahn.ApplicatonProcess.July2021.Domain.Models;
using  Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using  Hahn.ApplicatonProcess.July2021.Data.DataAccess;
namespace Hahn.ApplicatonProcess.July2021.Data.Repository
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
        
        public override async Task<bool> Update(User entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                                                        .FirstOrDefaultAsync();

                if(existingUser == null)
                    return false;
                existingUser.Age       = entity.Age;
                existingUser.FirstName = entity.FirstName;
                existingUser.LastName  = entity.LastName;
                existingUser.Address   = entity.Address;
                existingUser.Email     = entity.Email;
                existingUser.UserAssets    = entity.UserAssets;
    

                return true;
            }
            catch(Exception ex)
            {
                 this.logger.LogError(ex, "{Repo} Upsert method error", typeof(UserRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(object id)
        {
            try
            {   int idInt= int.Parse(id.ToString().Trim()); 
                var exist = await dbSet.Where(x => x.Id == idInt)
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

        public  User GetByUsername(string username){
            var user =  dbSet.SingleOrDefault(x => x.Username == username);
            return user;
        }
        public  bool UserExists(int id)
        {
            return   dbSet.Any(e => e.Id == id);
        }
        public  bool EmailExists(string email)
        {
            return   dbSet.Any(e => e.Email == email);
        }
        public bool EmailExistsByDiffrentId(int id, string email)
        {
            return   dbSet.Any(e => e.Email == email && !(e.Id   == id));
        }

    }
    
}