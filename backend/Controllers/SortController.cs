using backend.Handler;
using backend.Queries;
using backend.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace backend.Controllers
{
    //127.0.0.1/sort/
    [Route("sort")]
    public class SortController : ControllerBase
    {
        ILogger<SortController> _logger;

        ISortNumberHandler _handler;
        IDemo _demo;

        public SortController( ILogger<SortController> logger, ISortNumberHandler handler, IDemo demo)
        {
            _handler = handler;
            _logger = logger;
            _demo = demo;
        }

        [HttpPost]
        [Route("process-sort-number")]
        [ProducesResponseType(typeof(ActualSortResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SortNumbers([FromBody] GetStringNumber request)
        {
            _logger.LogInformation("bat xu ly sap xep so");
            return Ok(_handler.SortNumber(request));
        }

        [HttpGet]
        [Route("get-history")]
        [ProducesResponseType(typeof(IEnumerable<ActualSortResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetHistory()
        {
            _logger.LogInformation("bat xu ly lay history");
            _demo.sum(1,1);
            return Ok(_handler.GetHistory());
        }


    }


}
