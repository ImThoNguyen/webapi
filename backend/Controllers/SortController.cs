using backend.Data.Entities;
using backend.Data.Repositories;
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
        ICategoryRepository _categoryRepository;

        public SortController(ILogger<SortController> logger, ISortNumberHandler handler, ICategoryRepository categoryRepository)
        {
            _handler = handler;
            _logger = logger;
            _categoryRepository = categoryRepository;
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
            return Ok(_handler.GetHistory());
        }


        [HttpPost]
        [Route("save_category")]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> SaveCategory([FromBody] CreateCategory request)
        {
            var entity = new Category()
            {
                Content = request.Content,
                Id = request.Id,
                CreatedBy = request.CreatedBy,
                CreatedOn = request.CreatedOn,
                MetaTitle = request.MetaTitle,
                ModifiedBy = request.ModifiedBy,
                ModifiedOn = request.ModifiedOn,
                Slug = request.Slug,
                Title = request.Title
            };

            await _categoryRepository.AddOrUpdateAsync(request);
            await _categoryRepository.UnitOfWork.SaveChangesAsync();

            return Ok(entity);
        }



    }


}
