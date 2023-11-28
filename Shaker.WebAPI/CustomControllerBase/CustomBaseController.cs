using Microsoft.AspNetCore.Mvc;
using Shaker.Domain.Dtos.Response;

namespace Shaker.WebAPI.CustomControllerBase;

public class CustomBaseController : ControllerBase
{
    public IActionResult CreateActionResultInstance<T>(ResponseDto<T> responseDto)
    {
        return new ObjectResult(responseDto)
        {
            StatusCode = responseDto.StatusCode,
        };
    }
}
