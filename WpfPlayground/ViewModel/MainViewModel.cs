using System;
using System.Windows.Threading;
using WpfPlayground.Model;

namespace WpfPlayground.ViewModel
{
    class MainViewModel : ObservableObject
    {
        DispatcherTimer timer = new DispatcherTimer();

        private PlayerModel _player;
        public RelayCommand OverviewViewCommand { get; set; }
        public RelayCommand BuildingsViewCommand { get; set; }
        public OverviewViewModel OverviewVM { get; set;}
        public BuildingsViewModel BuildingsVM { get; set;}

        private object _currentView;
        public object CurrentView { get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public PlayerModel  Player { get => _player; 
            set
            {
                _player = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(0.5);

            _player = new PlayerModel();

            OverviewVM = new OverviewViewModel(Player);
            BuildingsVM = new BuildingsViewModel(Player);

            CurrentView = OverviewVM;

            OverviewViewCommand = new RelayCommand(o =>
            {
                CurrentView = OverviewVM;
            });

            BuildingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = BuildingsVM;
            });

            timer.Tick += Timer_Tick;
            timer.Start();
        }

        
        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Player.playerResources.Length; i++)
            {
                Player.playerResources[i].Value += Player.Multiplayers[i];
                OnPropertyChanged(nameof(Player));
            }   
        }
    }


}
