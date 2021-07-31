using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Hahn.ApplicatonProcess.July2021.Data.GenericRepository;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Service
{    /********************************************************
    *              Interface User Asset Service              *
    *********************************************************/
    public interface IUserAssetService : IGenericService<UserAsset>
    {
     Task<ResponseResult> GetAll();
    }
}