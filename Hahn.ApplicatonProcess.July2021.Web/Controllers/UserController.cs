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
using Hahn.ApplicatonProcess.July2021.Web.Service;
namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    /********************************************************
    *                     Users Controller                   *
    *********************************************************/

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IUserService userService;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userService = new UserService(unitOfWork);
        }

        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult>> GetUser(int id)
        {
            ResponseResult responseResult = await userService.GetById(id);
            return this.responseResult(responseResult);
        }


        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<object>> PostUser(User user)
        {
            ResponseResult responseResult = await userService.Insert(user);
            return this.responseResult(responseResult);
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutUser(int id, User user)
        {
            ResponseResult responseResult = await userService.Update(user, id);
            return this.responseResult(responseResult);
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteUser(int id)
        {
            ResponseResult responseResult = await userService.Delete(id);
            return this.responseResult(responseResult);
        }
    
        public ResponseResult responseResult(ResponseResult responseResult){
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                Response.StatusCode = 400;
                return responseResult;
            }
                
            Response.StatusCode = 200;
            return responseResult;

        }
    
    }
}