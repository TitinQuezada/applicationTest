using Core.Interfaces;
using Core.Managers;
using Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApplicationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermitTypesController : ControllerBase
    {
        private readonly PermitTypeManager _permitTypeManager;

        public PermitTypesController(PermitTypeManager permitTypeManager)
        {
            _permitTypeManager = permitTypeManager;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            IOperationResult<IEnumerable<PermitTypeViewModel>> operationResult = _permitTypeManager.GetAll();

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return Ok(operationResult.Entity);
        }
    }
}
