using System.ComponentModel;
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

namespace Bindings;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private string _myContent = string.Empty;

    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;
    }


    public string MyContent
    {
        get => _myContent;
        set
        {
            _myContent = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyContent)));
        }
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        MyContent = "1234";
        // MessageBox.Show(MyContent);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}