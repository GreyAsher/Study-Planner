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
using StudyPlanner.Views.AddViews;

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
    }
}

