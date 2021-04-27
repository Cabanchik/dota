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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(bool admRoot)
        {
            InitializeComponent();
            
         
        }
        
        
        private void teamsButton_Click(object sender, RoutedEventArgs e)
        {
            contentPage.Content = new TeamsPage();
        }

        private void tournamentButton_Click(object sender, RoutedEventArgs e)
        {
            contentPage.Content = new Tournaments();
        }

        private void gamesButton_Click(object sender, RoutedEventArgs e)
        {
            contentPage.Content = new GamesPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            admLogPage admLogPage = new admLogPage();
            admLogPage.ShowDialog();
            
        }






        //private void tourButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void gamesButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void teamsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame frame = new Frame()
        //    {
        //        Height = govno.Height,
        //        Width = govno.Width,
        //        Background = new SolidColorBrush()
        //    };
        //    frame.Content = new TeamsPage();
        //}


    }
}
