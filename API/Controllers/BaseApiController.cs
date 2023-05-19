using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This is the route for the controller ([controller] will be replaced with the name of the controller)
    public class BaseApiController : ControllerBase // This is the base controller for all the controllers in the API. 
    {

    }
}