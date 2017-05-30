using ChessGame.entities;
using ChessGame.entities.enums;
using ChessGame.utils;
using ChessGame.views.game;
using ChessGame.views.usercontrols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ChessGame.viewmodels
{
    public class MainGameVM
    {
        private Game game;
        private MainGame mainGame;



        public MainGameVM(MainGame mainGame)
        {
            this.mainGame = mainGame;
            game = new Game("game");
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

            ChessBoardUserControl chessBoardUC = new ChessBoardUserControl(this.game.ChessBoard);
            chessBoardUC.Name = "chessBoardUC";
            this.mainGame.mainGrid.Children.Add(chessBoardUC);
            Grid.SetRow(chessBoardUC, 0);
            Grid.SetColumn(chessBoardUC, 1);
            chessBoardUC.VerticalAlignment = VerticalAlignment.Stretch;
            chessBoardUC.HorizontalAlignment = HorizontalAlignment.Stretch;
        }

        private void InitCases()
        {
        }

        private void InitPieces()
        {
            this.game.Mode = Mode.CLASSICAL;//debug
            if (this.game.Mode== Mode.CLASSICAL)
            {
                //StackPanel stackPanel1 = (StackPanel)GetGridElement(CheckersGrid, currentMove.piece1.Row, currentMove.piece1.Column);

                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new QueenUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KingUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                                           
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new QueenUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KingUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new PawnUserControl());
            }
            else if (this.game.Mode == entities.enums.Mode.CLASSICAL)
            {
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new QueenUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KingUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new QueenUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                                           
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new QueenUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KingUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new QueenUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new RookUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new BishopUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
                //this.mainGame.ChessBoardUC.grid.Children.Add(new KnightUserControl());
            }


        }

        private void btnQuitGame_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            ChessBoardUserControl test = Utils.FindChild<ChessBoardUserControl>(this.mainGame, "chessBoardUC");
            StackPanel stackPanel = (StackPanel)test.GetGridElement(test.grid, test.ChessBoard.Pieces[5].XPosition, test.ChessBoard.Pieces[5].YPosition);
            PawnUserControl pp = (PawnUserControl)stackPanel.Children[0];
            stackPanel.Children.Remove(pp);
            StackPanel stackPane2 = (StackPanel)test.GetGridElement(test.grid, 4, 2);
            test.grid.Children.Remove(stackPane2);
            stackPane2.Children.Add(pp);
            test.grid.Children.Add(stackPane2);
            Grid.SetRow(stackPane2, 4);
            Grid.SetColumn(stackPane2, 2);
        }

        //public static T GetChildOfType<T>(this DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj == null) return null;

        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //    {
        //        var child = VisualTreeHelper.GetChild(depObj, i);

        //        var result = (child as T) ?? GetChildOfType<T>(child);
        //        if (result != null) return result;
        //    }
        //    return null;
        //}
    }
}
