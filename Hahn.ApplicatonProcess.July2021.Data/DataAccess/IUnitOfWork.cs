using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hahn.ApplicatonProcess.July2021.Data.DataAccess
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository UserRepository { get; }
        IAssetRepository AssetRepository { get; }
        void Save();
    }
}
