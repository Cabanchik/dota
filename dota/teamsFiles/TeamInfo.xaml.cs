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
    /// Логика взаимодействия для TeamInfo.xaml
    /// </summary>
    public partial class TeamInfo : Page
    {
        public TeamInfo(teams teams)
        {
            InitializeComponent();
            this.DataContext = teams;
            var count = (from t in App.dota2Entities.players
                           where t.team_id == teams.id
                           select t).Count();
            var players = (from t in App.dota2Entities.players
                           where t.team_id == teams.id
                           select t).ToList();

            for (int i = 0; i < count; i++)
            {
                StackPanel playerStack = new StackPanel()
                {                   
                    Orientation = Orientation.Vertical,
                    Margin = new Thickness(10,10,0,0)
                };
                Image pic = new Image()
                {

                    HorizontalAlignment = HorizontalAlignment.Center,
                    Width = 100,
                    Height = 100
                };
                Label playerName = new Label()
                {
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Label playerSurName = new Label()
                {
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Button button = new Button()
                {

                };
                pic.SetBinding(Image.SourceProperty, new Binding { Source = players[i], Path = new PropertyPath("profile_photo") });
                playerName.SetBinding(Label.ContentProperty, new Binding { Source = players[i], Path = new PropertyPath("name") });
                playerSurName.SetBinding(Label.ContentProperty, new Binding { Source = players[i], Path = new PropertyPath("surname") });
                playersStack.Children.Add(playerStack);
                playerStack.Children.Add(pic);
                playerStack.Children.Add(playerName);
                playerStack.Children.Add(playerSurName);
                playerStack.Children.Add(button);

                if (admLogPage.admRoot == true)
                {
                    button.Visibility = Visibility.Visible;
                }
                else
                {
                    button.Visibility = Visibility.Collapsed;
                }
            }
            


            //int  v = f;
            //moneyyy.Content = v * 110;

        }
    }
}
