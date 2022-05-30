using backend.Handler;
using backend.Queries;
using backend.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace backend.Controllers
{
    public class UserController : ControllerBase
    {
        private IRegistryUserHandler _iRegistryUserHandler;
        public UserController(IRegistryUserHandler iRegistryUserHandler)
        {
            _iRegistryUserHandler = iRegistryUserHandler;
        }
        [HttpPost]
        [Route("registry")]
        [ProducesResponseType(typeof(UserAcountResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> RegistryUser([FromBody] RegistryUser request)
        {
            return Ok(await _iRegistryUserHandler.SaveAccount(request));
        }


    }
}
