using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Mvvm.ViewModels;
using Mvvm.Views;

namespace Mvvm;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly IServiceCollection _services;
    private IServiceProvider? _serviceProvider;

    public App()
    {
        _services = new ServiceCollection();
        _serviceProvider = null;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        _services.AddSingleton<MainView>();
        _services.AddSingleton<MainViewModel>();

        // ... rest services

        _serviceProvider = _services.BuildServiceProvider();

        var mainView = _serviceProvider.GetRequiredService<MainView>();

        mainView.Show();
    }
}