using Microsoft.AspNetCore.Mvc;
using Shaker.Application.Services;
using Shaker.Domain.Models.ShakersModel;
using Shaker.WebAPI.CustomControllerBase;

namespace Shaker.WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ShakersController : CustomBaseController
{
    #region Fields
    private readonly IShakersService _shakersService;
    #endregion


    #region Ctor
    public ShakersController
    (
        IShakersService shakersService
    )
    {
        _shakersService = shakersService;
    }
    #endregion


    #region Methods
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllShakers()
    {
        var res = await _shakersService.GetAllShakers();
        return Ok(res);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateShakers(CreateShakersModel model)
    {
        await _shakersService.CreateShaker(model);
        return Ok("Success");
    }
    #endregion
}
