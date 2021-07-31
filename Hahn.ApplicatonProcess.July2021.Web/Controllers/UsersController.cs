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
    public class UsersController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IUserService userService;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userService = new UserService(unitOfWork);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult>> GetUser(int id)
        {
            ResponseResult responseResult = await userService.GetById(id);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                Response.StatusCode = 400;
                return responseResult;
            }
            Response.StatusCode = 200;
            return responseResult;
        }


        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<object>> PostUser(User user)
        {
            ResponseResult responseResult = await userService.Insert(user);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                Response.StatusCode = 400;
                return responseResult;
            }
                
            Response.StatusCode = 200;
            return responseResult;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutUser(int id, User user)
        {
            ResponseResult responseResult = await userService.Update(user, id);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                Response.StatusCode = 400;
                return responseResult;
            }
                
            Response.StatusCode = 200;
            return responseResult;
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteUser(int id)
        {
            ResponseResult responseResult = await userService.Delete(id);
            if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.ERROR)){
                Response.StatusCode = 400;
                return responseResult;
            }
                
            Response.StatusCode = 200;
            return responseResult;
        }
    
    }
}