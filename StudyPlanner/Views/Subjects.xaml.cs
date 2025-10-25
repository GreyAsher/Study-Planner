using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
using StudyPlanner.Views.AddViews;
using StudyPlanner.Views.InfoControl;

namespace StudyPlanner.Views
{
    /// <summary>
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : UserControl
    {
        private readonly ISubjectService _subjectservice;
        private readonly SubjectViewModel _subjectViewModel;
        private readonly Subject _subjects;
        public Subjects(SubjectViewModel subjectViewModel/*, ISubjectService subjectservice, Subject subject*/)
        {
            InitializeComponent();
            _subjectViewModel = subjectViewModel;
       //     _subjectservice = subjectservice;
       //     _subject = subject;
            DataContext = _subjectViewModel;

            this.Loaded += async (s, e) => await _subjectViewModel.LoadSubjects();
        }

        private async void AddSubjectButton_Click(object sender, RoutedEventArgs e)
        {
            AddSubjectWindow addSubjectWindow = new AddSubjectWindow(_subjectservice, _subjects);
            addSubjectWindow.ShowDialog();
            await _subjectViewModel.LoadSubjects();
        }
        private async void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected subject from the button's DataContext
                var button = sender as Button;
                var selectedSubject = button?.DataContext as Subject;

                if (selectedSubject == null)
                    return;

                // Create the detail view
                var detailView = new StudyPlanner.Views.InfoControl.SubjectInfo
                {
                    DataContext = selectedSubject
                };

                // Replace this UserControl’s content
                if (this.Content is Grid grid)
                {
                    grid.Children.Clear();
                    grid.Children.Add(detailView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening subject details: {ex.Message}");
            }
        }
    }
}

