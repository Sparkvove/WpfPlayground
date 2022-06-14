using WpfPlayground.Model;
using System.Windows.Input;

namespace WpfPlayground.ViewModel
{
    public class BuildingsViewModel : ObservableObject
    {
        private PlayerModel _player;
        public PlayerModel Player { get => _player;
            set 
            {
                _player = value;
                OnPropertyChanged();
            }
        }

        public BuildingModel CarbonFiberBuilding { get => _player.CarbonFiberBuilding;
            set 
            {
                _player.CarbonFiberBuilding = value;
                OnPropertyChanged(nameof(CarbonFiberBuilding));
            }
        }
        public RelayCommand UpgradeCarbonFiberBuilding { get; set; }
        public BuildingsViewModel(PlayerModel player)
        {
            Player = player;

            UpgradeCarbonFiberBuilding = new RelayCommand(o =>
            {
                _player.upgradeBuilding(CarbonFiberBuilding);
                 OnPropertyChanged(nameof(CarbonFiberBuilding));
                OnPropertyChanged(nameof(Player.playerResources));
            },
            (o => {
                CommandManager.InvalidateRequerySuggested();
                return _player.canUpgradeBuilding(CarbonFiberBuilding); })
            );
        }
    }




}
