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
    public class AddressController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        private IAddressService addressService;

        public AddressController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            addressService = new AddressService(unitOfWork);
        }

        // GET: api/address/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResult>> GetAddress(int id)
        {
            ResponseResult responseResult = await addressService.GetById(id);
            responseResult =  addressService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }

        // POST: api/address
        [HttpPost]
        public async Task<ActionResult<ResponseResult>> PostAddress(Address address)
        {
            ResponseResult responseResult = await addressService.Insert(address);
            responseResult =  addressService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }

        // PUT: api/asset/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseResult>> PutAddress(int id, Address address)
        {
            ResponseResult responseResult = await addressService.Update(address, id);
            responseResult =  addressService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }

        // DELETE: api/asset/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseResult>> DeleteAddress(int id)
        {
            ResponseResult responseResult = await addressService.Delete(id);
            responseResult =  addressService.responseResult(responseResult);
            Response.StatusCode = responseResult.StatusCode;
            return responseResult;
        }
    
        
    }
}