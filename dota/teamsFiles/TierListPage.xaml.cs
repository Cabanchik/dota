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
    /// Логика взаимодействия для TierListPage.xaml
    /// </summary>
    public partial class TierListPage : Page
    {
        public TierListPage()
        {
            InitializeComponent();
            var tierListCount = (from t in App.dota2Entities.teams.ToList()
                                 orderby t.dpc_points
                                 select t).ToList().Count();
            var tierList = (from t in App.dota2Entities.teams
                            orderby t.dpc_points descending
                            select t).ToList();
            //var teams = (from t in App.dota2Entities.teams
            //             select t);
            //MainWindow mainWindow = new MainWindow();
            Label positionTier = new Label()
            {
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = "Tier:",


            };
            Label teamTitle = new Label()
            {
                VerticalContentAlignment = VerticalAlignment.Center,
                Content = "Team title:",


            };
            Label teamLogoTitle = new Label()
            {
                Content = "Team\nLogo:",
                Width = 40,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            Label dpcTitle = new Label()
            {
                Content = "Dpc\npoints:",
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center

            };
            dpcStack.Children.Add(dpcTitle);
            titleStack.Children.Add(positionTier);
            titleStack.Children.Add(teamLogoTitle);
            titleStack.Children.Add(teamTitle);


            for (int i = 0; i < tierListCount; i++)
            {
                Label tierNumber = new Label()
                {
                    Content = i + 1,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 5, 0),
                    FontSize = 20,

                };

                StackPanel teamStack = new StackPanel()
                {
                    Height = 50,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(1, 1, 0, 5),
                    Orientation = Orientation.Horizontal,




                };
                Image teamLogo = new Image()
                {
                    Height = 40,
                    Width = 40,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center

                };
                Label teamLabel = new Label()
                {
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 26
                };

                Label dpcPoints = new Label()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 26,


                };

                teamLabel.SetBinding(Label.ContentProperty, new Binding { Source = tierList[i], Path = new PropertyPath("title") });
                teamLogo.SetBinding(Image.SourceProperty, new Binding { Source = tierList[i], Path = new PropertyPath("team_logo") });
                dpcPoints.SetBinding(Label.ContentProperty, new Binding { Source = tierList[i], Path = new PropertyPath("dpc_points") });
                teamStack.Children.Add(tierNumber);
                teamStack.Children.Add(teamLogo);
                teamStack.Children.Add(teamLabel);


                stack.Children.Add(teamStack);
                StackPanel childStack = new StackPanel()
                {
                    Height = 50,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(1, 1, 0, 5),
                    Orientation = Orientation.Vertical,

                };
                childStack.Children.Add(dpcPoints);
                pointsStack.Children.Add(childStack);

            }



        }

    }
}

