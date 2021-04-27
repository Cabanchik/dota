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
    /// Логика взаимодействия для Game.xaml
    /// </summary>
    public partial class Game : Page
    {
        public Game(games games)
        {
            //MainWindow mp = new MainWindow();
            this.DataContext = games;//a
            InitializeComponent();


        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            deleteGameForm deleteGameForm = new deleteGameForm();
            deleteGameForm.ShowDialog();
        }
    }
}
