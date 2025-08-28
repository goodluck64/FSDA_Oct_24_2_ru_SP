using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO.Compression;
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

namespace UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Stopwatch stopwatch = new Stopwatch();
    
    public MainWindow()
    {
        InitializeComponent();

        DataContext = this;

        Processes = new();
        stopwatch.Start();
        
        // GZipStream
    }

    public ObservableCollection<ProcessData> Processes { get; set; }

    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            MyTextBlock.Foreground = new SolidColorBrush(Color.FromRgb(
                (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue),
                (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue),
                (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue)));

            MyTextBlock.Background = new SolidColorBrush(Color.FromRgb(
                (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue),
                (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue),
                (byte)Random.Shared.Next(byte.MinValue, byte.MaxValue)));


            var currentProcess = Process.GetCurrentProcess();

            currentProcess.PriorityClass = ProcessPriorityClass.RealTime;
            currentProcess.ProcessorAffinity = new IntPtr(1 | 2 | 128);

            // 0b10000011 - CPU 0 & CPU 1 & CPU 7
            // 0b00000011 - CPU 0 & CPU 1
            // 0b00000010 - CPU 1
            // 0b00000001 - CPU 0

            //MessageBox.Show($"Process Count: {Environment.ProcessorCount} \nName:{currentProcess.ProcessName}");

            var procs = Process.GetProcesses();

            Processes.Clear();

            foreach (var process in procs)
            {
                try
                {
                    Processes.Add(new ProcessData
                    {
                        Id = process.Id,
                        Name = process.ProcessName,
                    });
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            var myArgs = Environment.GetCommandLineArgs();

            MessageBox.Show(string.Join(' ', myArgs));
            stopwatch.Stop();
            MessageBox.Show(stopwatch.Elapsed.ToString());
            // Process.Start(@"C:\Users\Alex\RiderProjects\FSDA_Oct_24_2_ru_SP\Proccesses\bin\Debug\net9.0\Proccesses.exe",
            //     new string[] { "arg1", "arg2", "argX" });
        }
    }
}