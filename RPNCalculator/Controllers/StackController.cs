using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RPN.Application.Interfaces;
using RPN.Domain.Exceptions;
using RPN.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace RPNCalculator.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StackController : ControllerBase
    {
        private readonly IStackService _stackService;

        public StackController(IStackService stackService)
        {
            _stackService = stackService;
        }
        /// <summary>
        /// get a stack by id
        /// </summary>
        /// <param name="stackId"></param>
        /// <returns></returns>
        [HttpGet("{stackId}")]
        public IActionResult GetStack(Guid stackId)
        {
            try
            {
                var stack = _stackService.GetStack(stackId);
                return Ok(stack);
            }
            catch (StackNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// clear stack
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/clear/{stackId}")]
        public IActionResult ClearStack(Guid stackId)
        {
            try
            {
                _stackService.ClearStack(stackId);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
        /// <summary>
        /// create a new stack
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateStack()
        {
            try
            {
                var stack = _stackService.CreateStack();
                return new OkObjectResult(stack);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// delete stack by id
        /// </summary>
        /// <param name="stackId"></param>
        /// <returns></returns>
        [HttpDelete("{stackId}")]
        public IActionResult DeleteStack(Guid stackId)
        {
            try
            {
                _stackService.RemoveStack(stackId);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}