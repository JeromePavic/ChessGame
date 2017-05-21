using ChessGame.entities;
using ChessGame.views.game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessGame.viewmodels
{
    public class MainGameVM
    {
        private Game game;
        private MainGame mainGame;



        public MainGameVM(MainGame mainGame)
        {
            this.mainGame = mainGame;

            InitUC();
            InitLUC();
            InitActions();
        }

        private void InitActions()
        {
            this.mainGame.btnSaveGame.Click += btnSaveGame_Click;
            this.mainGame.btnQuitGame.Click += btnQuitGame_Click;
        }

        private void InitLUC()
        {
           
        }

        private void InitUC()
        {
            game = new Game();
            this.mainGame.ChessBoardUC. = currentZoo;
        }

        private void btnQuitGame_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
