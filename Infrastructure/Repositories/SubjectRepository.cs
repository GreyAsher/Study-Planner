using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppService.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly Persistence.AppDbContext _context;
        public SubjectRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);
            return await Task.FromResult(subject);
        }
        public async Task AddSubjectAsync(Domain.Entities.Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateSubjectAsync(Domain.Entities.Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteSubjectAsync(int subjectId)
        {
            var subject = _context.Subjects.Find(subjectId);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
    }
}
