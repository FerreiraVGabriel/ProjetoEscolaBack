using Infra.Entities.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Input;
using Services.Interfaces;
using Services.Services;

namespace Api.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize]
        [HttpGet("Pagination")]
        public async Task<object> Pagination([FromQuery] SearchParams searchParams)
        {
            var result = await _studentService.GetPaginationAsync(searchParams);

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(new
                {
                    errorType = error.ErrorType.ToString(),
                    detail = error.Detail
                })
            );
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(StudentInputDTO studentInput)
        {
            var result = await _studentService.Add(studentInput);

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(new
                {
                    errorType = error.ErrorType.ToString(),
                    detail = error.Detail
                })
            );
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> Update(StudentInputDTO studentInput)
        {
            var result = await _studentService.Update(studentInput);

            return result.Match<IActionResult>(
                success => Ok(success),
                error => BadRequest(new
                {
                    errorType = error.ErrorType.ToString(),
                    detail = error.Detail
                })
            );
        }

        [Authorize]
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.Delete(id);

            return result.Match<IActionResult>(
                success => success ? Ok(true) : BadRequest(false),
                error => BadRequest(new
                {
                    errorType = error.ErrorType.ToString(),
                    detail = error.Detail
                })
            );
        }
    }
}
