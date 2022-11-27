using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NavigationDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleTooltips(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                Visibility vis = button.IsChecked ?? false ? Visibility.Collapsed : Visibility.Visible;
                
                tt_contacts.Visibility = vis;
                tt_messages.Visibility = vis;
                tt_maps.Visibility = vis;
                tt_home.Visibility = vis;
                tt_settings.Visibility = vis;
                tt_signout.Visibility = vis;
            }
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }
    }
}