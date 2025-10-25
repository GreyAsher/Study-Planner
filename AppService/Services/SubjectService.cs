using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppService.Interfaces;
using AppService.Interfaces.Repository;
using Domain.Entities;

namespace AppService.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository ?? throw new ArgumentNullException(nameof(subjectRepository));
        }
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _subjectRepository.GetAllSubjectsAsync();
        }
        public async Task<Subject> GetSubjectByIdAsync(int subjectId)
        {
            return await _subjectRepository.GetSubjectByIdAsync(subjectId);
        }
        public async Task AddSubjectAsync(Subject subject)
        {
            await _subjectRepository.AddSubjectAsync(subject);
        }
        public async Task UpdateSubjectAsync(Subject subject)
        {
            await _subjectRepository.UpdateSubjectAsync(subject);
        }
        public async Task DeleteSubjectAsync(int subjectId)
        {
            await _subjectRepository.DeleteSubjectAsync(subjectId);
        }
    }
}
