using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using SunsetLibrary;

namespace SunsetAppDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _maxNumber = 0;
        private int _currentNumber = 0;
        
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void LoadNextAsync(object sender, RoutedEventArgs e)
        {
            _currentNumber = (_currentNumber + 1) % _maxNumber;
            
            await LoadComicAsync(_currentNumber);
        }

        private async void LoadPreviousAsync(object sender, RoutedEventArgs e)
        {
            _currentNumber = (_currentNumber - 1 +_maxNumber) % _maxNumber;

            await LoadComicAsync(_currentNumber);
        }

        private async Task LoadComicAsync(int comicNumber)
        {
            var comic = await ComicProcessor.LoadComic(comicNumber);
            if (comicNumber == 0)
                _maxNumber = comic.Num;

            _currentNumber = comic.Num;
            
            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            ComicImage.Source = new BitmapImage(uriSource);
        }

        private async void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            await LoadComicAsync(0);
        }

        private void LoadSunInformation(object sender, RoutedEventArgs e)
        {
            new SunInfo().Show();
            this.Close();
        }
    }
}