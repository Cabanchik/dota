using System;
using System.Collections.Generic;
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

namespace dota
{
    /// <summary>
    /// Логика взаимодействия для GamesPage.xaml
    /// </summary>
    public partial class GamesPage : Page
    {
        public GamesPage()
        {

            MainWindow window = new MainWindow(admLogPage.admRoot);
            InitializeComponent();
            
            var teamsInGames = (from t in App.dota2Entities.teams
                                select t).ToList();

           

            view.ItemsSource = App.dota2Entities.games.ToList();
            window.SizeChanged += Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           

        }

        private void view_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var game = view.SelectedItem as games;
            this.NavigationService.Navigate(new Game(game));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addGameForm addGameButton = new addGameForm();
            addGameButton.ShowDialog();
        }
    }
}
