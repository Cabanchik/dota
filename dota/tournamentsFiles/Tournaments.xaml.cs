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
    /// Логика взаимодействия для Tournaments.xaml
    /// </summary>
    public partial class Tournaments : Page
    {
        NavigationService nav;

        public Tournaments()
        {
            nav = NavigationService.GetNavigationService(this);
            InitializeComponent();

            //listview.ItemsSource = (from t in App.dota2Entities.tournaments
            //                        select t).ToList();
            var tournListCount = (from t in App.dota2Entities.tournaments
                                  select t).ToList().Count;
            var tournList = (from t in App.dota2Entities.tournaments
                             select t).ToList();
            MainWindow mainWindow = new MainWindow(admLogPage.admRoot);


            for (int i = 0; i < tournListCount; i++)
            {
                Button button = new Button()
                {
                    Width = mainWindow.Width * 0.3,
                    Height = 100,



                };


                button.SetBinding(Button.ContentProperty, new Binding { Source = tournList[i], Path = new PropertyPath("title") });
                button.SetBinding(Button.BackgroundProperty, new Binding { Source = tournList[i], Path = new PropertyPath("tournament_pic") });
                wrap.Children.Add(button);
                button.Click += Button_Click;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var sas = (from s in App.dota2Entities.tournaments.ToList()
                       where s.title == button.Content.ToString()
                       select s).First();
            this.NavigationService.Navigate(new TournInfo(sas));
            //nav.NavigationService.Navigate(new Uri("Tournaments.xaml"),UriKind.RelativeOrAbsolute);
        }
    }
}

