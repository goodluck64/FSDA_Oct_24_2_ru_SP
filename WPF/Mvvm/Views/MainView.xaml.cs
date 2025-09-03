using System.Windows;
using Mvvm.ViewModels;

namespace Mvvm.Views;

public partial class MainView : Window
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        ((MainViewModel)DataContext).ViewModel = new SecondViewModel();
    }
}