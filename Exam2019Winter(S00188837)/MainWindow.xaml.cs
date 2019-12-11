using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exam2019Winter_S00188837_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Players> AllPlayers;
        ObservableCollection<Players> SelectedPlayers;
        ObservableCollection<Players> FilteredPlayers;

        Random rng = new Random();
        int Selected = 0;


        public MainWindow()
        {
            InitializeComponent();
            AllPlayers = new ObservableCollection<Players>();
            SelectedPlayers = new ObservableCollection<Players>();
            FilteredPlayers = new ObservableCollection<Players>();

            for (int i = 0; i < 18; i++)
            {
                AllPlayers.Add(GetRandomPlayers());
            }
        }

        private void LeftLsb_Loaded(object sender, RoutedEventArgs e)
        {
            
            LeftLsb.ItemsSource = null;
            LeftLsb.ItemsSource = AllPlayers;

            RightLsb.ItemsSource = null;
            RightLsb.ItemsSource = SelectedPlayers;
        }

        private Players GetRandomPlayers()
        {
            //get random position
            Players.PlayerType[] type = { Players.PlayerType.Goalkeeper, Players.PlayerType.Defender, Players.PlayerType.Midfielder, Players.PlayerType.Forward };
            int randomNumber = rng.Next(0,4); //0,1,2,3
            string position = type[randomNumber].ToString();

            //get random First Name
            string[] Names = { "Domas", "Tomas", "Micheal", "Sophie", "Luke", "Sean", "Ava" };
            int randomName = rng.Next(0, 6); //0,1,2,3,4,5
            string Name = Names[randomName];

            //get random Surname
            string[] SurNames = { "O'Neill","Walsh","Lynch","Daly","McCarthy","Brennan","Dunne" };
            int randomSurName = rng.Next(0, 6); //0,1,2,3,4,5
            string SurName = SurNames[randomSurName];

            //get random date - last  years + Age
            DateTime RandomDate()
            {
                DateTime start = new DateTime(1989,1,1);
                DateTime End = new DateTime(1999,1,1);
                int range = (End - start).Days;
                return start.AddDays(rng.Next(range));
            }

            //create Player with random info
            Players p1 = new Players(Name,SurName,RandomDate(),type[randomNumber]);

            return p1;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Players selected = LeftLsb.SelectedItem as Players;

            if (selected != null && Selected != 11)
            {
                SelectedPlayers.Add(selected);
                Selected++;
                LeftLsb.ItemsSource = null;
                LeftLsb.ItemsSource = SelectedPlayers;

                AllPlayers.Remove(selected);
                LeftLsb.ItemsSource = null;
                LeftLsb.ItemsSource = AllPlayers;
            }

            _spaces.Text = Selected.ToString();
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            Players selected = RightLsb.SelectedItem as Players;

            if (selected != null)
            {
            //
                AllPlayers.Add(selected);
                Selected--;
                LeftLsb.ItemsSource = null;
                LeftLsb.ItemsSource = SelectedPlayers;

                SelectedPlayers.Remove(selected);
                LeftLsb.ItemsSource = null;
                LeftLsb.ItemsSource = AllPlayers;
            }
            _spaces.Text = Selected.ToString();
        }

       
    }
}
