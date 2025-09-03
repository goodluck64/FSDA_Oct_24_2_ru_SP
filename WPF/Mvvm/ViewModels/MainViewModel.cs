using CommunityToolkit.Mvvm.ComponentModel;

namespace Mvvm.ViewModels;

[INotifyPropertyChanged]
public partial class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        ViewModel = new FirstViewModel();
    }

    [ObservableProperty] private ViewModelBase _viewModel;
}