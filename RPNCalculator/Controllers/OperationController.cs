using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RPN.Application.Interfaces;
using RPN.Domain.Exceptions;
using RPN.Domain.Models;

namespace RPN.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OperationController : Controller
    {
        private readonly IOperationService _operationService;

        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }
        /// <summary>
        /// insert operand to a stack
        /// </summary>
        /// <param name="stackId"></param>
        /// <param name="operand"></param>
        /// <returns></returns>
        [HttpPost("{stackId}/operand")]
        public IActionResult AddOperand(Guid stackId, [FromBody] Operand operand)
        {
            try
            {
                var stack = _operationService.AddOperand(stackId, operand);
                return new OkObjectResult(stack);
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
        /// apply an operator to a stack
        /// </summary>
        /// <param name="stackId"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        [HttpPost("{stackId}/operator")]
        public IActionResult AddOperator(Guid stackId, string operation)
        {
            try
            {
                var stack = _operationService.AddOperation(stackId, operation);
                return new OkObjectResult(stack);

            }
            catch (OperationNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (StackNotFoundException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (DivideByZeroException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// List all supported operations
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult GetAllSupportedOperators()
        {
            try
            {
                return Ok(_operationService.GetSuportedOperations());

            }
            catch (StackNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
