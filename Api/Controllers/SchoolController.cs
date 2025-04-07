using Infra.Entities.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneOf.Types;
using Services.Dtos.Input;
using Services.Interfaces;
using Services.Services;

namespace Api.Controllers
{
    [Authorize]
    [Route("v1/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _schoolService;
        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }


        [Authorize]
        [HttpGet("Pagination")]
        public async Task<object> Pagination([FromQuery] SearchParams searchParams)
        {
            var result = await _schoolService.GetPaginationAsync(searchParams);

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
        [HttpGet("All")]
        public async Task<object> All()
        {
            var result = await _schoolService.GetAllAsync();

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
        public async Task<IActionResult> Add(SchoolInputDTO schoolInputDTO)
        {
            var result = await _schoolService.Add(schoolInputDTO);

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
        public async Task<IActionResult> Update(SchoolInputDTO schoolInputDTO)
        {
            var result = await _schoolService.Update(schoolInputDTO);

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
            var result = await _schoolService.Delete(id);

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
