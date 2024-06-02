using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NowAssessment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
