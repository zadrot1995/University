using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Commands.Students;
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

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentByIdAsync(int studentId)
        {
            var query = new GetStudentByIdQuery(studentId);
            var result = await mediator.Send(query);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync([FromBody] CreateStudentCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentAsync(int studentId)
        {
            var command = new DeleteStudentCommand
            {
                Id = studentId
            };
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> UpdateStudentAsync(int studentId, [FromBody] UpdateStudentCommand command)
        {
            command.Id = studentId;
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
