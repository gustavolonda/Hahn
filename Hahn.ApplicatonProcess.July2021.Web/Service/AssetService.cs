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
    public class AssetService : GenericService<Asset>, IAssetService
    {
        /********************************************************
       *              Implements Asset Service                  *
       *********************************************************/
        public AssetService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        private const string ASSET_NOT_EXIST = "Asset not exist";
        public override async Task<ResponseResult> GetById(object id){
            var asset = await _unitOfWork.AssetRepository.GetById(id);
            ResponseResult responseResult = new ResponseResult();
            if (asset == null)
            {
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                responseResult.ErrorMessages.Add(ASSET_NOT_EXIST);
                return responseResult;
            } 
            responseResult.ResultStatus = ResponseResultStatusDomain.OK;
            responseResult.ResultMessage = FINISHED_SUCCESSFULLY;   
            responseResult.Response = asset;

            return responseResult;
        }
        public override async Task<ResponseResult> Insert(Asset asset){

            
            ResponseResult responseResult = new ResponseResult();
            try
            {
                bool isInsert = await  _unitOfWork.AssetRepository.Insert(asset);
                _unitOfWork.Save();
                responseResult = await  GetById(asset.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                responseResult = new ResponseResult();
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                responseResult.ErrorMessages.Add(ERROR_OCURRED);
                return responseResult;
            }

            
             return responseResult;

        }
            
        public override async Task<ResponseResult> Update(Asset asset, object idWhereUpdate){
            ResponseResult responseResult = await GetById(idWhereUpdate);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR))
                return responseResult;
            try
            {
               bool isUpdate = await _unitOfWork.AssetRepository.Update(asset);
               if(isUpdate)
                _unitOfWork.Save();
                 return await GetById(asset.Id);
            }
            catch (DbUpdateConcurrencyException)
            {
                responseResult = new ResponseResult();
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                responseResult.ErrorMessages.Add(ERROR_OCURRED);
                return responseResult;
            }
        }
        public override async Task<ResponseResult> Delete(object id){


            ResponseResult responseResult = new ResponseResult();
            try
            {
                responseResult = await  GetById(id);
                if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR))
                    return responseResult;
                bool isDelete = await _unitOfWork.AssetRepository.Delete(id);
                _unitOfWork.Save();

            }
            catch (DbUpdateConcurrencyException)
            {
                responseResult = new ResponseResult();
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                responseResult.ErrorMessages.Add(ERROR_OCURRED);
                return responseResult;
            }
           
            responseResult = new ResponseResult();
            responseResult.ResultStatus = ResponseResultStatusDomain.OK;
            responseResult.ResultMessage = FINISHED_SUCCESSFULLY;
            responseResult.Response = true;
            return responseResult;
    
        }   

    }
    
}