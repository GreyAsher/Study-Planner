using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppService.Interfaces;
using AppService.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace StudyPlanner.Views
{
    /// <summary>
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : UserControl
    {
       // private readonly ISubjectService _subjectservice;
        private readonly SubjectViewModel _subjectViewModel;
       // private readonly Subject _subject;
        public Subjects(SubjectViewModel subjectViewModel/*, ISubjectService subjectservice, Subject subject*/)
        {
            InitializeComponent();
            _subjectViewModel = subjectViewModel;
       //     _subjectservice = subjectservice;
       //     _subject = subject;
            DataContext = _subjectViewModel;
            //_ = TestDatabaseConnectionAsync();

            // Load subjects

            this.Loaded += async (s, e) => await _subjectViewModel.LoadSubjects();
            //this.Loaded += Subjects_Loaded;
        }
       /* private async void Subjects_Loaded(object sender, RoutedEventArgs e)
        {
            
            await LoadSubjectsAsync();
        }

        private async Task LoadSubjectsAsync()
        {
            try
            {
                await _subjectViewModel.LoadSubjects();

                if (_subjectViewModel.Subjects.Count == 0)
                {
                    MessageBox.Show("No subjects found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading subjects: {ex.Message}");
            }
        }*/

    }
}

