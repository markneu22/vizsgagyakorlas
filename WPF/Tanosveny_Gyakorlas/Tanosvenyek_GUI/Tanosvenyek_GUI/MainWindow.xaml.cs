using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
using Tanosvenyek_GUI.Models;

namespace Tanosvenyek_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        TanosvenyContext context = new();
        public ObservableCollection<Telepules> Telepulesek { get; set; }
        public ObservableCollection<Utvonal> Utvonalak { get; set; }
        private ObservableCollection<Utvonal> kijeloltUtvonalak;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? tulajdonsagnev = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(tulajdonsagnev));

        public ObservableCollection<Utvonal> KijeloltUtvonalak
        {
            get { return kijeloltUtvonalak; }
            set { kijeloltUtvonalak = value; OnPropertyChanged(); }
        }

        private Utvonal selectedUtvonal;

        public Utvonal SelectedUtvonal
        {
            get { return selectedUtvonal; }
            set { selectedUtvonal = value; OnPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            context.Ut.Load();
            context.Telepules.Load();
            Telepulesek = context.Telepules.Local.ToObservableCollection();
            Utvonalak = context.Ut.Local.ToObservableCollection();
        }

        private void varosok_CBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Telepules selected = (Telepules)varosok_CBX.SelectedItem;
            if (selected != null)
            {
                KijeloltUtvonalak = new ObservableCollection<Utvonal>(context.Ut.Local.Where(x => x.telepulesid == selected.id));
            }
        }

        private void data_DG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Utvonal dgSelected = (Utvonal)data_DG.SelectedItem;
            if (dgSelected != null)
            {
                SelectedUtvonal = dgSelected;
            }
        }
    }
}