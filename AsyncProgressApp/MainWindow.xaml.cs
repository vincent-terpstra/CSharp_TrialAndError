using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncProgressApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _cts = new CancellationTokenSource();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void executeSync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            List<WebsiteDataModel> results = DemoMethods.RunDownload();

            PrintResults(results);
            watch.Stop();
            
            var elapsedMs = watch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: {elapsedMs}";
        }
        
        private async void executeAsync_Click(object sender, RoutedEventArgs e)
        {
            Progress <ProgressReportModel>  progress = new();
            progress.ProgressChanged += ReportProgress;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                ResultsWindow.Text = String.Empty;
                List<WebsiteDataModel> results = await DemoMethods.RunDownloadAsync(progress, _cts.Token);
                PrintResults(results);
            }
            catch (OperationCanceledException ex)
            {
                ResultsWindow.Text += $"Operation canceled by {Environment.UserName} {Environment.NewLine}";
            }
            finally
            {
                _cts = new();
            }

            
            watch.Stop();
            
            var elapsedMs = watch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: {elapsedMs}{Environment.NewLine}";
        }

        private void ReportProgress(object? sender, ProgressReportModel e)
        {
            ProgressBar.Value = e.PercentageComplete;
            var item = e.CurrentSite;
            ResultsWindow.Text += $"{item.WebsiteUrl} downloaded: {item.WebsiteData.Length} characters{Environment.NewLine}";
        }

        private async void executeParallelAsync_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Progress <ProgressReportModel>  progress = new();
            progress.ProgressChanged += ReportProgress;
            ResultsWindow.Text = String.Empty;
            List<WebsiteDataModel> results = await DemoMethods.RunDownloadParallelAsyncV2(progress);

            PrintResults(results);
            watch.Stop();
            
            var elapsedMs = watch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: {elapsedMs}";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            _cts.Cancel();
        }
        
        private void PrintResults(List<WebsiteDataModel> results)
        {
            ResultsWindow.Text = String.Empty;
            foreach (var item in results)
            {
                ResultsWindow.Text += $"{item.WebsiteUrl} downloaded: {item.WebsiteData.Length} characters{Environment.NewLine}";
            }
        }
    }
}