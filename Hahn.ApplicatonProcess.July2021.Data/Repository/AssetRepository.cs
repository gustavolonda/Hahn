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
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        /********************************************************
       *              Implements User Repository                *
       *********************************************************/
        public AssetRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {
            
        }
        public override async Task<Asset> GetById(int id)
        {
             try
            {
                return await dbSet.FindAsync(id);
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex,  "{Repo} Upsert method error", typeof(AssetRepository));
                return new Asset();
                
            }
            
        } 
        public override async Task<bool> Update(Asset entity)
        {
            try
            {
                var existingAsset = await dbSet.Where(x => x.Id == entity.Id)
                                                        .FirstOrDefaultAsync();

                if(existingAsset == null)
                    return await Insert(entity);

                existingAsset.Symbol = entity.Symbol;
                existingAsset.Name   = entity.Name;

                return true;
            }
            catch(Exception ex)
            {
                 this.logger.LogError(ex, "{Repo} Upsert method error", typeof(AssetRepository));
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
                 this.logger.LogError(ex, "{Repo} Delete method error", typeof(AssetRepository));
                return false;
            }
        }
    }
}