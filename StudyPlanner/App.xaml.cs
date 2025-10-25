using System.IO;
using System.Windows;
using System.Windows.Threading;
using AppService.Interfaces;
using AppService.Interfaces.Repository;
using AppService.Services;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudyPlanner.Views;


namespace StudyPlanner;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider
    {
        get; private set;
    }
    public static IConfiguration Configuration
    {
        get; private set;
    }
    private readonly ISubjectService _subjectService;
    protected override void OnStartup(StartupEventArgs e)
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        DispatcherUnhandledException += App_DispatcherUnhandledException;

        try
        {
            ShutdownMode = ShutdownMode.OnMainWindowClose;
            LoadConfiguration();

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            var loginWindow = ServiceProvider.GetRequiredService<MainWindow>();
            bool? result = loginWindow.ShowDialog();
            if (result == true)
            { 
                var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
                MainWindow = mainWindow;
                mainWindow.Show();

                ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            else
            {
                Shutdown();
            }
        }
        catch (System.Exception ex)
        {
            MessageBox.Show($"An error occurred during application startup: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            Shutdown();
        }
        base.OnStartup(e);
    }

    private void ConfigureServices(ServiceCollection services)
    {
        try
        {

            // Use SQLite DefaultConnection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db")}"));


            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<SubjectViewModel>();
            services.AddScoped<Subjects>();
            services.AddTransient<MainWindow>();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred while configuring services: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            throw;
        }
    }

    private void LoadConfiguration()
    {
        Configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
             .Build();
    }
    
     private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        MessageBox.Show($"An unhandled exception occurred: {(e.ExceptionObject as Exception)?.Message}", "Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        MessageBox.Show($"An unhandled dispatcher exception occurred: {e.Exception.Message}", "Dispatcher Unhandled Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        e.Handled = true;
    }
}

