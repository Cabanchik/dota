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
using System.Windows.Shapes;

namespace dota
{
    /// <summary>
    /// Логика взаимодействия для admLogPage.xaml
    /// </summary>
    public partial class admLogPage : Window
    {
        public static bool admRoot = false;
        public admLogPage()
        {
            InitializeComponent();
            

        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(admRoot)
            {

            };
            if (password.Text.ToString() == "123")
            {
                lbl.Content = "Пароль введен\nуспешно";
                admRoot = true;
                this.Close();
                window.Show();
                
            }
            else
            {
                lbl.Content = "Пароль неверен";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(admRoot)
            {

            };
            this.Close();
            window.Show();
        }
    }
}
