using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.July2021.Web.Helper;
using Hahn.ApplicatonProcess.July2021.Web.Service;
using Hahn.ApplicatonProcess.July2021.Domain.Models;
using Newtonsoft.Json;


namespace Hahn.ApplicatonProcess.July2021.Web.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            System.Console.WriteLine("Gus "+ token);
            var userId = jwtUtils.ValidateToken(token);
            

            if (userId != null)
            {  
                // attach user to context on successful jwt validation
                ResponseResult responseResult = await userService.GetById(userId.Value);
                if(responseResult.ResultStatus.Equals(ResponseResultStatusDomain.OK)){
                    var userJson = JsonConvert.SerializeObject(responseResult.Response);
                    context.Items["User"] = JsonConvert.DeserializeObject<User>(userJson);
                }
            }

            await _next(context);
        }
    }
}