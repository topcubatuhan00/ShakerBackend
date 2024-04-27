using Microsoft.AspNetCore.Mvc;
using Shaker.Application.Services;
using Shaker.Domain.Models.ShakerOptionsModel;
using Shaker.WebAPI.CustomControllerBase;

namespace Shaker.WebAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class ShakerOptionsController : CustomBaseController
{
    #region Fields
    private readonly IShakerOptionsService _shakerOptionsService;
    #endregion

    #region Ctor
    public ShakerOptionsController
    (
        IShakerOptionsService shakerOptionsService
    )
    {
        _shakerOptionsService = shakerOptionsService;
    }
    #endregion

    #region Methods
    [HttpGet("[action]/{id:int}")]
    public async Task<IActionResult> GetShakerOptions(int id)
    {
        var res = await _shakerOptionsService.GetShakerOptions(id);
        return Ok(res);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateShakerOptions(CreateShakerOptionsModel model)
    {
        await _shakerOptionsService.CreateShakerOptions(model);
        return Ok("Success");
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> UpdateShakerOptions(UpdateShakerOptionsModel model)
    {
        await _shakerOptionsService.UpdateShakerOptions(model);
        return Ok("Success");
    }
    #endregion
}
