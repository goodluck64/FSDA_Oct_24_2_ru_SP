using System.Windows;

namespace SynchronizationEventsUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Thread _counterThread;
    private ManualResetEvent _counterEvent;
    private int _counter = 0;
    private SynchronizationContext _synchronizationContext;

    public MainWindow()
    {
        InitializeComponent();

        _counterThread = new Thread(CounterThreadCallback);
        _counterEvent = new ManualResetEvent(false);

        _synchronizationContext = SynchronizationContext.Current ??
                                  throw new InvalidOperationException("SynchronizationContext.Current is null.");
    }

    private void StartButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (!_counterThread.IsAlive)
        {
            _counterThread.Start();
        }

        _counterEvent.Set();
    }

    private void StopButton_OnClick(object sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void PauseButton_OnClick(object sender, RoutedEventArgs e)
    {
        _counterEvent.Reset();
    }

    private void CounterThreadCallback()
    {
        bool flag = true;
        
        while (flag)
        {
            _counterEvent.WaitOne();
            _synchronizationContext.Send(_ =>
            {
                CounterProgressBar.Value = _counter;
                CounterTextBlock.Text = (_counter++).ToString();

                if (_counter == (int)CounterProgressBar.Maximum)
                {
                    flag = false;
                }
            }, null);


            Thread.Sleep(100);
        }
    }
}