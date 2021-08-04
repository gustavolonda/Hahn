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
    *                     Asset Controller                   *
    *********************************************************/

    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IAssetService assetService;

        public AssetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            assetService = new AssetService(unitOfWork);
        }

        // GET: api/asset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult>> GetUser(string id)
        {
            ResponseResult responseResult = await assetService.GetById(id);
            responseResult =  assetService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }


        // POST: api/asset
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> PostAsset(Asset asset)
        {
            ResponseResult responseResult = await assetService.Insert(asset);
            responseResult =  assetService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }

        // PUT: api/asset/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> PutAsset(string id, Asset asset)
        {
            ResponseResult responseResult = await assetService.Update(asset, id);
            responseResult =  assetService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }

        // DELETE: api/asset/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteAsset(string id)
        {
            ResponseResult responseResult = await assetService.Delete(id);
            responseResult =  assetService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }
    
    }
}