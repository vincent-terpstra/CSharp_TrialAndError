using ModernDesignDemo.Core;

namespace ModernDesign.MVVM.ViewModel;

public class MainViewModel : ObservableObject
{
    public RelayCommand DiscoveryViewCommand { get;  }

    public RelayCommand HomeViewCommand { get; }
    public MainViewModel()
    {
        _HomeViewModel = new();
        _discoveryViewModel = new();
        CurrentView = _HomeViewModel;

        DiscoveryViewCommand = new RelayCommand(
            o =>
        {
            CurrentView = _discoveryViewModel;
        });
        HomeViewCommand = new RelayCommand(
            o =>
        {
            CurrentView = _HomeViewModel;
        });
    }
    
    private readonly HomeViewModel _HomeViewModel;
    private readonly DiscoveryViewModel _discoveryViewModel;
    
    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }
}