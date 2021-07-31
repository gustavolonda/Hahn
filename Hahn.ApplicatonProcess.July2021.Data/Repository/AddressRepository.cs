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
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        /********************************************************
       *              Implements User Repository                *
       *********************************************************/
        public AddressRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {
            
        }
        public override async Task<bool> Update(Address entity)
        {
            try
            {
                var existingAsset = await dbSet.Where(x => x.Id == entity.Id)
                                                        .FirstOrDefaultAsync();

                if(existingAsset == null)
                    return false;

                existingAsset.PostatCode  = entity.PostatCode;
                existingAsset.Street      = entity.Street;
                existingAsset.HouseNumber = entity.HouseNumber;

                return true;
            }
            catch(Exception ex)
            {
                 this.logger.LogError(ex, "{Repo} Upsert method error", typeof(AssetRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(object id)
        {
            try
            {  
                int idInt= int.Parse(id.ToString().Trim()); 
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
                 this.logger.LogError(ex, "{Repo} Delete method error", typeof(AssetRepository));
                return false;
            }
        }
    }
}