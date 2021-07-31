using Hahn.ApplicatonProcess.July2021.Data.Repository;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Logging;
namespace Hahn.ApplicatonProcess.July2021.Data.DataAccess
{
    public interface IUnitOfWork: IDisposable
    {   
        IUserRepository UserRepository { get; }
        IAssetRepository AssetRepository { get; }
        IAddressRepository AddressRepository { get; }
        ILogger Logger { get; }
        void Save();
    }
}
