using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University.Core.Helpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator mediator;

        public StudentController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 0, [FromQuery] int size = Constants.PageSize)
        {
            var query = new GetAllStudentsQuery
            {
                Page = page,
                Size = size
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
