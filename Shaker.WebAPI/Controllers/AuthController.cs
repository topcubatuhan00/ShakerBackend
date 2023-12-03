using Microsoft.AspNetCore.Mvc;
using Shaker.Application.Services;
using Shaker.Domain.Models.AuthModels;
using Shaker.WebAPI.CustomControllerBase;

namespace Shaker.WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : CustomBaseController
{
    #region Fields
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public AuthController
    (
        IConfiguration configuration,
        IAuthService authService
    )
    {
        _configuration = configuration;
        _authService = authService;
    }
    #endregion

    #region Methods

    // Login
    [HttpPost("[action]")]
    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    {
        var token = await _authService.Login(model);
        return Ok(token);
    }

    // register
    [HttpPost("[action]")]
    public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
    {
        await _authService.Register(model);
        return Ok("Success");
    }

    #endregion
}
