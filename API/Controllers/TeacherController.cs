using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Commands;
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
            var query = new GetAllTeacherQuery
            {
                Page = page,
                Size = size
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int teacherId)
        {

            var query = new GetTeachersByIdQuery(teacherId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacherAsync([FromBody] CreateTeacherCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> DeleteTeacherAsync(int teacherId)
        {
            var command = new DeleteTeacherCommand
            {
                Id = teacherId
            };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> UpdateTeacherAsync(int teacherId, [FromBody] UpdateTeacherCommand command)
        {
            command.Id = teacherId;
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
