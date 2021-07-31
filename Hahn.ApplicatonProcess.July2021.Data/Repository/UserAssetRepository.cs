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
    public class UserAssetRepository : GenericRepository<UserAsset>, IUserAssetRepository
    {
        /********************************************************
       *            Implements User Asset Repository            *
       *********************************************************/
        public UserAssetRepository(
            AppDbContext context,
            ILogger logger
        ) : base(context, logger)
        {
            
        }
    }
}