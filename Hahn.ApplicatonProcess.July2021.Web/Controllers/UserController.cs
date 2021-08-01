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
using Hahn.ApplicatonProcess.July2021.Web.Authorization;
using AutoMapper;
using Microsoft.Extensions.Options;
namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    /// <summary>
        /// Get the source data of each indicator
        /// </summary>
        /// <returns></returns>
    /********************************************************
    *                     Users Controller                   *
    *********************************************************/
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public UserController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        // GET: api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult>> GetUser(int id)
        {
            ResponseResult responseResult = await userService.GetById(id);
            responseResult =  userService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }


        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<object>> PutUser(int id, User user)
        {
            ResponseResult responseResult = await userService.Update(user, id);
            responseResult =  userService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ResponseResult>> PostRegister(RegisterRequest model)
        {
            ResponseResult responseResult = await userService.Register(model);
            responseResult =  userService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public  ActionResult<ResponseResult>  Authenticate(AuthenticateRequest model)
        {
            var responseResult = userService.Authenticate(model);
            responseResult =  userService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteUser(int id)
        {
            ResponseResult responseResult = await userService.Delete(id);
            responseResult =  userService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }
    


       
    
    }
}