using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hahn.ApplicatonProcess.July2021.Data.DataAccess
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Asset> AssetRepository { get; }
        void Save();
    }
}
