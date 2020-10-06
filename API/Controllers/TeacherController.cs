using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Core.Helpers;

namespace University.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 0, [FromQuery] int size = Constants.PageSize)
        {
            //var query = new GetCarWashesQuery
            //{
            //    Page = page,
            //    Size = size
            //};

            //var result = await _mediator.Send(query);

            return Ok();
        }
    }
}
