using Games_GUI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
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

namespace Games_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        GamesContext context = new();
        public ObservableCollection<PublisherModel> Publishers { get; set; }
        private ObservableCollection<GameModel> games;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string tulajdonsagnev)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagnev));
        }

        public ObservableCollection<GameModel> Games
        {
            get { return games; }
            set { games = value; OnPropertyChanged("Games"); }
        }

        private GameModel selectedgame;

        public GameModel SelectedGame
        {
            get { return selectedgame; }
            set { selectedgame = value; OnPropertyChanged("SelectedGame"); }
        }



        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            context.Game.Load();
            context.Publisher.Load();
            Publishers = context.Publisher.Local.ToObservableCollection();
        }

        private void publishers_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PublisherModel selected = (PublisherModel)publishers_CBX.SelectedItem;
            if (selected != null)
            {
                Games = new ObservableCollection<GameModel>(context.Game.Local.Where(x => x.PublisherId == selected.Id));
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GameModel dgSelected = (GameModel)data_DG.SelectedItem;
            if (dgSelected != null)
            {
                SelectedGame = dgSelected;
            }
        }
    }
}