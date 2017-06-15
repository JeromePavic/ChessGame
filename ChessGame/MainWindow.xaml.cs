using ChessGame.database.entitiesLinks;
using ChessGame.views.administration;
using ChessGame.views.game;
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

namespace ChessGame
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            window.Content = new MainAdmin();
            window.Show();
        }

        private void btnGame_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Content = new OptionsAdmin();
            window.Show();

            //MySQLGameManager msqlGM = new MySQLGameManager();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Loading game will be soon available", "Not available",
                   System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            return;
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
