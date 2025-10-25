using System.Collections.ObjectModel;
using System.Windows;
using AppService.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using StudyPlanner;

public class SubjectViewModel : BaseViewModel
{
    private readonly ISubjectService _subjectservice;
    public ObservableCollection<Subject> Subjects { get; set; } = new();

    public SubjectViewModel(ISubjectService subjectservice)
    {
        _subjectservice = subjectservice ?? throw new ArgumentNullException(nameof(subjectservice));
        Subjects = new ObservableCollection<Subject>();
        _ = LoadSubjects();
    }

    public async Task LoadSubjects()
    {
        try
        {
           
            Subjects.Clear();

            var subjects = await _subjectservice.GetAllSubjectsAsync();
            foreach (var subject in subjects)
            {
                Subjects.Add(subject);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log them)
            Console.WriteLine($"Error loading subjects: {ex.Message}");
        }
    }
    public async Task AddSubject(Subject subject)
    {
        if (subject == null) throw new ArgumentNullException(nameof(subject));
        await _subjectservice.AddSubjectAsync(subject);
        Subjects.Add(subject);
    }
}
