using ChessGame.views.administration;
using ChessGame.views.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ChessGame.viewmodels
{
    public class MainAdminVM
    {
        private MainAdmin mainAdmin;

        public MainAdminVM(MainAdmin mainAdmin)
        {
            this.mainAdmin = mainAdmin;

            InitUC();
            InitLUC();
            InitActions();
        }

        private void InitActions()
        {
        }

        private void InitLUC()
        {
            
        }

        private void InitUC()
        {
            
        }



        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Content = new MainGame();
            window.Show();
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            Page optionPage = new OptionsAdmin();
            this.mainAdmin.NavigationService.Navigate(optionPage);
        }
    }
}
