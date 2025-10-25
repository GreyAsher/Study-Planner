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
using System.Windows.Shapes;
using AppService.Interfaces;
using AppService.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace StudyPlanner.Views.AddViews
{
    /// <summary>
    /// Interaction logic for AddSubjectWindow.xaml
    /// </summary>
    public partial class AddSubjectWindow : Window
    {
        private readonly ISubjectService _subjectService;

        public AddSubjectWindow(ISubjectService subjectService, Subject? subject)
        {
            InitializeComponent();
            _subjectService = App.ServiceProvider.GetRequiredService<ISubjectService>();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SubjectNameTextBox.Text))
            {
                MessageBox.Show("Subject Name is required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                int targetHours = int.Parse(TargetHoursTextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Target Hours must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var existingSubjects = await _subjectService.GetAllSubjectsAsync();
                bool subjectExists = existingSubjects.Any(s => s.SubjectName.Equals(SubjectNameTextBox.Text, StringComparison.OrdinalIgnoreCase));

                if (subjectExists)
                {
                    MessageBox.Show("A subject with this name already exists.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else
                {
                    var newSubject = new Subject
                    {
                        SubjectName = SubjectNameTextBox.Text,
                        Description = DescriptionTextBox.Text,
                        Progress = 0,
                        TargetHours = int.Parse(TargetHoursTextBox.Text)
                    };

                    await _subjectService.AddSubjectAsync(newSubject);
                    MessageBox.Show("Subject added successfully!");
                    this.Close();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking existing subjects: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            /*// Logic to save the new subject
            string subjectName = SubjectNameTextBox.Text;
            
            this.Close();*/
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the window without saving
            this.Close();
        }
    }
}
