using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Hahn.ApplicatonProcess.July2021.Data.DataAccess;
using Hahn.ApplicatonProcess.July2021.Domain.Validators;
namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
     /********************************************************
    *                     Users Controller                   *
    *********************************************************/

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GetAllUsers
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()

        {
            var result = await _unitOfWork.UserRepository.GetAll();
            return new ActionResult<IEnumerable<User>> (result);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }
            user.Address = await _unitOfWork.AddressRepository.GetById(user.AddressId);    

            return user;
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutUser(int id, User user)
        {
            // User Validator
            UserValidator userValidator = new UserValidator();
            ResponseResultValidator resultValidator = userValidator.CheckErrorExists(user,userValidator);
            if(resultValidator.IsError){
                Response.StatusCode = 400;
                 return resultValidator;
            }
              

            // Address Validator
            AddressValidator addresValidator = new AddressValidator();
            ResponseResultValidator resultAddressValidator = addresValidator.CheckErrorExists(user.Address,addresValidator);
            if(resultAddressValidator.IsError){
                Response.StatusCode = 400;
                 return resultAddressValidator;
            }
              
          

        
            if (id != user.Id)
            {

                return BadRequest();
            }

            try
            {
               bool isUpdate = await _unitOfWork.UserRepository.Update(user);
               if(isUpdate)
                _unitOfWork.Save();
                 return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.UserRepository.UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<object>> PostUser(User user)
        {
            UserValidator userValidator = new UserValidator();
            ResponseResultValidator resultValidator = userValidator.CheckErrorExists(user,userValidator);
            if(resultValidator.IsError){
                Response.StatusCode = 400;
                 return resultValidator;
            }
            // Address Validator
            AddressValidator addresValidator = new AddressValidator();
            ResponseResultValidator resultAddressValidator = addresValidator.CheckErrorExists(user.Address,addresValidator);
            if(resultAddressValidator.IsError){
                Response.StatusCode = 400;
                 return resultAddressValidator;
            }

              
            // Check Email Exists
            if (_unitOfWork.UserRepository.EmailExists(user.Email)){
                resultValidator = new ResponseResultValidator();
                resultValidator.IsError = true;
                Response.StatusCode = 400;
                resultValidator.ErrorMessages.Add("Email Exist");
                return resultValidator;

            }
               

           //bool isAddressInsert =  await  _unitOfWork.AddressRepository.Insert(user.Address);
           //if(isAddressInsert)
           {
               bool isInsert = await  _unitOfWork.UserRepository.Insert(user);
             _unitOfWork.Save();
           }
            

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
             bool isDelete = await _unitOfWork.UserRepository.Delete(id);
             _unitOfWork.Save();

            return user;
        }
    
    }
}