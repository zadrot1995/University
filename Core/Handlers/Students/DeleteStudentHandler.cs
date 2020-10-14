using Core.Commands.Students;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers.Students
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand>
    {
        private readonly UniversityIdentityDbContext _context;

        public DeleteStudentHandler(UniversityIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = _context.Students.Where(s => s.Id == request.Id).FirstOrDefault();
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
