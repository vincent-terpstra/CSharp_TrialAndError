using System.Globalization;
using System.Windows;
using SunsetLibrary;

namespace SunsetAppDemo;

public partial class SunInfo : Window
{
    public SunInfo()
    {
        InitializeComponent();
    }

    private async void LoadSunInfoAsync(object sender, RoutedEventArgs e)
    {
        SunriseModel model = await SunriseProcessor.LoadSunriseModel();

        SunriseText.Text = model.Sunrise.ToLocalTime().ToShortTimeString();
        SunsetText.Text = model.Sunset.ToLocalTime().ToShortTimeString();
    }
}