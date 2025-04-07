
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.Input;
using Services.Interfaces;


namespace Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public AuthenticationController(ITokenService tokenService, IUserService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost(template: "Login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserInputDTO userInput)
        {

            var existingUser = await _userService.GetByNomeAsync(userInput.SNome);

            if (existingUser == null || (userInput.SSenha != existingUser.SSenha))
            {
                return BadRequest(new
                {
                    errorType = "InvalidCredentials",
                    detail = "Email ou senha inválidos."
                });

            }

            var token = _tokenService.GenerateToken(existingUser);

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new
                {
                    errorType = "TokenGenerationError",
                    detail = "Erro ao gerar token."
                });
            }

            return Ok(new { Token = token });
        }

    }
}
