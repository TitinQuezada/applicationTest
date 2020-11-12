using Core.Interfaces;
using Core.Managers;
using Core.Models;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitsController : ControllerBase
    {
        private readonly PermitManager _permitManager;

        public PermitsController(PermitManager permitManager)
        {
            _permitManager = permitManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PermitCreateOrEditViewModel permit)
        {
            IOperationResult<bool> operationResult = await _permitManager.Create(permit);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(PermitCreateOrEditViewModel permit)
        {
            IOperationResult<bool> operationResult = await _permitManager.Update(permit);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IOperationResult<IEnumerable<Permit>> operationResult = _permitManager.GetAll();

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok();
        }

        [HttpDelete("{permitId}")]
        public async Task<IActionResult> Delete(int permitId)
        {
            IOperationResult<bool> operationResult = await _permitManager.Delete(permitId);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok();
        }
    }
}
