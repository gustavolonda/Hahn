using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using  Hahn.ApplicatonProcess.July2021.Domain.Models;
using  Hahn.ApplicatonProcess.July2021.Data.DataAccess;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
namespace Hahn.ApplicatonProcess.July2021.Web.Service
{
    public class UserAssetService : GenericService<UserAsset>, IUserAssetService
    {
        /********************************************************
       *              Implements Asset Service                  *
       *********************************************************/
        public UserAssetService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        public async Task<ResponseResult> GetAll(){
            var userAssets = await  _unitOfWork.UserAssetRepository.GetAll();
            ResponseResult responseResult = new ResponseResult();
            responseResult.ResultStatus = ResponseResultStatusDomain.OK;
            responseResult.ResultMessage = FINISHED_SUCCESSFULLY;   
            responseResult.Response = userAssets;
            return  responseResult;
        }
    }
    
}