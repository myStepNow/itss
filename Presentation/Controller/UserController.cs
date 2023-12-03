using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/user")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserController : ControllerBase
    {
        
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(IHttpContextAccessor httpContextAccessor, IServiceManager manager)
        {
            _contextAccessor = httpContextAccessor;
        }

        [HttpGet(Name = "GetAdName")]
        public IActionResult Get()
        {
            string? username = _contextAccessor.HttpContext.User.Identity.Name;

            return Ok(username ?? "yok");
        }
    }

}
