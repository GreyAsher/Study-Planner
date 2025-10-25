using System.Text;
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
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using StudyPlanner.Views;

namespace StudyPlanner;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ISubjectService _subjectservice;
    private readonly SubjectViewModel _subjectViewModel;
    private readonly Subject _subject;
    public MainWindow()
    {
        InitializeComponent();
    }

    public MainWindow(ISubjectService subjectService)
    {
        InitializeComponent();
        _subjectservice = subjectService;
        MainContent.Content = new Dashboard();
    }
    private void DashboardButton_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new Dashboard();
    }
    private void TodayButton_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new Today();
    }

    private void CalendarButton_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new CalendarUC();
    }

    private void SubjectsButton_Click(object sender, RoutedEventArgs e)
    {
        var subjectsView = App.ServiceProvider.GetRequiredService<Subjects>();
        MainContent.Content = subjectsView;
    }

    private void GoalsButton_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new Goals();
    }

    private void NotesButton_Click(object sender, RoutedEventArgs e)
    {
        MainContent.Content = new Notes();
    }

  }