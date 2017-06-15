using ChessGame.entities;
using ChessGame.views.administration;
using ChessGame.views.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using ChessGame.database;
using ChessGame.entities.enums;

namespace ChessGame.viewmodels
{
    public class OptionsAdminVM
    {
        private OptionsAdmin optionsAdmin;
        private Game currentGame;
        //private Map currentMap;
        private MySQLManager<Map> mapManager = new MySQLManager<Map>();
        //private Theme currentThemeP1;
        //private Theme currentThemeP2;
        private MySQLManager<Theme> themeManager = new MySQLManager<Theme>();
        private Int32 currentMode;

        public OptionsAdminVM(OptionsAdmin optionsAdmin)
        {
            this.optionsAdmin = optionsAdmin;
            currentGame = new Game();
            currentGame.Background = false;
            currentGame.Mode = Mode.CLASSICAL;
            currentGame.Name = "game_" + DateTime.Now.ToString();
            currentGame.Player1 = new Player("Player1", null, State.ALIVE, false, true, 0);
            currentGame.Player2 = new Player("Player2", null, State.ALIVE, false, false, 0);
            InitUC();
            InitLUC();
            InitActions();
        }

        private void InitUC()
        {

        }

        private async void InitLUC()
        {
            this.optionsAdmin.ListMapUC.LoadItems((await mapManager.Get()).ToList());
            this.optionsAdmin.ListMapUC.IsEnabled = false;
            this.optionsAdmin.ListThemeP1UC.LoadItems((await themeManager.Get()).ToList());
            this.optionsAdmin.ListThemeP2UC.LoadItems((await themeManager.Get()).ToList());
        }

        private void InitActions()
        {
            this.optionsAdmin.btnPlay.Click += BtnPlay_Click;
            this.optionsAdmin.btnCancel.Click += BtnCancel_Click;
            this.optionsAdmin.ListMapUC.ItemsList.SelectionChanged += MapItemsList_SelectionChanged;
            this.optionsAdmin.ListThemeP1UC.ItemsList.SelectionChanged += ThemeP1ItemsList_SelectionChanged;
            this.optionsAdmin.ListThemeP2UC.ItemsList.SelectionChanged += ThemeP2ItemsList_SelectionChanged;
            this.optionsAdmin.rbChess.Checked += RbChecked;
            this.optionsAdmin.rbFlying.Checked += RbChecked;
            this.optionsAdmin.rbWar.Checked += RbChecked;
            this.optionsAdmin.rbMad.Checked += RbChecked;
            this.optionsAdmin.ckbP1Help.Checked += P1HelpChecked;
            this.optionsAdmin.ckbP1Help.Unchecked += P1HelpUnchecked;
            this.optionsAdmin.ckbP2Help.Checked += P2HelpChecked;
            this.optionsAdmin.ckbP2Help.Unchecked += P2HelpUnchecked;
            this.optionsAdmin.ckbMap.Checked += MapChecked;
            this.optionsAdmin.ckbMap.Unchecked += MapUnchecked;
        }

        private void P1HelpChecked(object sender, RoutedEventArgs e)
        {
            currentGame.Player1.Help = true;
        }

        private void P1HelpUnchecked(object sender, RoutedEventArgs e)
        {
            currentGame.Player1.Help = false;
        }

        private void P2HelpChecked(object sender, RoutedEventArgs e)
        {
            currentGame.Player2.Help = true;
        }

        private void P2HelpUnchecked(object sender, RoutedEventArgs e)
        {
            currentGame.Player2.Help = false;
        }

        private void MapChecked(object sender, RoutedEventArgs e)
        {
            currentGame.Background = true;
            this.optionsAdmin.ListMapUC.IsEnabled = true;
        }

        private void MapUnchecked(object sender, RoutedEventArgs e)
        {
            currentGame.Background = false;
            this.optionsAdmin.ListMapUC.IsEnabled = false;
        }

        private void RbChecked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            currentMode = Convert.ToInt32(radioButton.Content.ToString());
        }

        private void ThemeP2ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                currentGame.Player2.Theme = (e.AddedItems[0] as Theme);
        }

        private void ThemeP1ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                currentGame.Player1.Theme = (e.AddedItems[0] as Theme);
        }

        private void MapItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
                currentGame.Map = (e.AddedItems[0] as Map);
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            // Set values to players
            if (this.optionsAdmin.txtBP1Name.Text.Length > 0)
                this.currentGame.Player1.Name = this.optionsAdmin.txtBP1Name.Text;
            try
            {
                this.currentGame.Player1.TimerSec = Convert.ToInt32(this.optionsAdmin.txtBP1Timer.Text);
            }
            catch (Exception)
            {
                this.currentGame.Player1.TimerSec = 0;
            }

            if (this.optionsAdmin.txtBP2Name.Text.Length > 0)
                this.currentGame.Player2.Name = this.optionsAdmin.txtBP2Name.Text;
            try
            {
                this.currentGame.Player2.TimerSec = Convert.ToInt32(this.optionsAdmin.txtBP2Timer.Text);
            }
            catch (Exception)
            {
                this.currentGame.Player2.TimerSec = 0;
            }

            // Set values to game
            if (!currentGame.Background)
                currentGame.Map = null;

            switch (currentMode)
            {
                case 0 :
                    currentGame.Mode = Mode.CLASSICAL;
                    break;
                case 1:
                    currentGame.Mode = Mode.FLYING;
                    break;
                case 2:
                    currentGame.Mode = Mode.WAR;
                    break;
                case 3:
                    currentGame.Mode = Mode.MAD;
                    break;
                default:
                    break;
            }
            currentGame.ChessBoard = new ChessBoard(currentGame.Mode);
            currentGame.SetPiecesPlayer();

            // Launch game
            Window window = new Window();
            window.Content = new MainGame(currentGame);
            window.Show();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window w = (Window)this.optionsAdmin.Parent;
            w.Close();
        }
    }
}
