using Microsoft.AspNetCore.Mvc;

namespace NowAssessment.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
