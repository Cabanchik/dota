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
    /// Логика взаимодействия для TeamsPage.xaml
    /// </summary>
    public partial class TeamsPage : Page
    {
        public TeamsPage()
        {
            InitializeComponent();
            //view.ItemsSource = App.dota2Entities.teams.ToList();
            var count = (from t in App.dota2Entities.teams.ToList()
                         select t).Count();
            var teams = (from t in App.dota2Entities.teams.ToList()
                         select t).ToList();
            for (int i = 0; i < count; i++)
            {
                StackPanel teamStack = new StackPanel()
                {
                    Orientation = Orientation.Vertical
                };
                Image teamlogo = new Image()
                {
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                Button teamLabel = new Button()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Background = Brushes.Transparent
                };
                teamlogo.SetBinding(Image.SourceProperty, new Binding { Source = teams[i], Path = new PropertyPath("team_logo") });
                teamLabel.SetBinding(Button.ContentProperty, new Binding { Source = teams[i], Path = new PropertyPath("title") });
                teamLabel.Click += TeamLabel_Click;
                teamStack.Children.Add(teamlogo);
                teamStack.Children.Add(teamLabel);
                wrap.Children.Add(teamStack);
            }
        }

        private void TeamLabel_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var sas = (from s in App.dota2Entities.teams.ToList()
                       where s.title == button.Content.ToString()
                       select s).First();
            this.NavigationService.Navigate(new TeamInfo(sas));
        }
    }
}
