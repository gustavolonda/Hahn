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
    public class UserService : GenericService<User>, IUserService
    {
        /********************************************************
       *              Implements User Repository                *
       *********************************************************/
        public UserService(
            IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }
        private const string FINISHED_SUCCESSFULLY = "Finished successfully";
        private const string ERROR_OCURRED = "Error occurred";
        private const string USER_NOT_EXIST = "User not exist";
        public override async Task<ResponseResult> GetById(object id){
            var user = await _unitOfWork.UserRepository.GetById(id);
              ResponseResult responseResult = new ResponseResult();
            if (user == null)
            {
                    responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                     responseResult.ErrorMessages.Add(USER_NOT_EXIST);
                    return responseResult;
            }
            user.Address = await _unitOfWork.AddressRepository.GetById(user.AddressId); 
            responseResult.ResultStatus = ResponseResultStatusDomain.OK;
            responseResult.ResultMessage = FINISHED_SUCCESSFULLY;   
            responseResult.Response = user;

            return responseResult;
        }
        public override async Task<ResponseResult> Insert(User user){

            
            ResponseResult responseResult = validador(user, true,0);
            if(responseResult!=null)
                return responseResult;
            try
            {
                bool isInsert = await  _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Save();
                responseResult = await  GetById(user.Id);
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
            
        public override async Task<ResponseResult> Update(User user, object idWhereUpdate){
            ResponseResult responseResult = validador(user, false, Convert.ToInt32(idWhereUpdate));
            if(responseResult!=null)
                return responseResult;
            try
            {
               bool isUpdate = await _unitOfWork.UserRepository.Update(user);
               if(isUpdate)
                _unitOfWork.Save();
                 return await GetById(user.Id);
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

            }
            catch (DbUpdateConcurrencyException)
            {
                responseResult = new ResponseResult();
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                responseResult.ErrorMessages.Add(ERROR_OCURRED);
                return responseResult;
            }
           
            
          
             bool isDelete = await _unitOfWork.UserRepository.Delete(id);
             _unitOfWork.Save();
             responseResult = new ResponseResult();
            responseResult.ResultStatus = ResponseResultStatusDomain.OK;
            responseResult.ResultMessage = FINISHED_SUCCESSFULLY;
            responseResult.Response = true;
            return responseResult;
    
        }   

         public ResponseResult validador(User user, bool isInsert, int idWhereUpdate){
             UserValidator userValidator = new UserValidator();
            ResponseResult responseResult = userValidator.CheckErrorExists(user,userValidator);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                 return responseResult;
            }
            // Address Validator
            AddressValidator addresValidator = new AddressValidator();
            responseResult = addresValidator.CheckErrorExists(user.Address,addresValidator);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                 return responseResult;
            }
            if(isInsert){
                // Check Email Exists
                if (_unitOfWork.UserRepository.EmailExists(user.Email)){
                    responseResult = new ResponseResult();
                    responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                    responseResult.ErrorMessages.Add("Email Exist");
                    return responseResult;

                }
                return null;
            }
            // Check Email Exists
            if (_unitOfWork.UserRepository.EmailExistsByDiffrentId(idWhereUpdate, user.Email)){
                responseResult = new ResponseResult();
                responseResult.ResultStatus = ResponseResultStatusDomain.ERROR;
                responseResult.ErrorMessages.Add("Email Exist");
                return responseResult;

            }
            return null;
         }        

    }
    
}