using ChessGame.database;
using ChessGame.entities;
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
        private MySQLManager<Map> mapManager = new MySQLManager<Map>();


        public MainAdminVM(MainAdmin mainAdmin)
        {
            this.mainAdmin = mainAdmin;

            InitUC();
            InitLUC();
            InitActions();
        }

        private void InitActions()
        {
            this.mainAdmin.btnNewMap.Click += BtnNewMap_Click;
            this.mainAdmin.btnNewTheme.Click += BtnNewTheme_Click;
            this.mainAdmin.btnRemoveMap.Click += BtnRemoveMap_Click;
            this.mainAdmin.btnRemoveTheme.Click += BtnRemoveTheme_Click;
            this.mainAdmin.btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            Window w = (Window)this.mainAdmin.Parent;
            w.Close();
        }

        private void BtnRemoveTheme_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnRemoveMap_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnNewTheme_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void InitLUC()
        {
            this.mainAdmin.ListMapUC.LoadItem((await mapManager.Get()).ToList());
            this.mainAdmin.ListThemeUC.LoadItem((await mapManager.Get()).ToList());
        }

        private void InitUC()
        {
            
        }




//------------------------

        private void BtnNewMap_Click(object sender, RoutedEventArgs e)
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
