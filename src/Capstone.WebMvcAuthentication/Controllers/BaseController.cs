using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Users.WebMvcAuthentication.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
