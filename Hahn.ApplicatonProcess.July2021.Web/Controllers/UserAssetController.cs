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
    /// <summary>
        /// Get the source data of each indicator
        /// </summary>
        /// <returns></returns>
    /********************************************************
    *                 User Asset Controller                 *
    *********************************************************/

    [Route("api/[controller]")]
    [ApiController]
    public class UserAssetController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IUserAssetService userAssetService;

        public UserAssetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userAssetService = new UserAssetService(unitOfWork);
        }

        // GET: api/userAsset
        [HttpGet("")]
        public async Task<ActionResult<ResponseResult>> GetAll()
        {
            ResponseResult responseResult = await userAssetService.GetAll();
            return responseResult;
        }
    }
}
