using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Core.Helpers;

namespace University.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator mediator;

        public TeacherController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 0, [FromQuery] int size = Constants.PageSize)
        {
            var query = new GetAllTeachersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
