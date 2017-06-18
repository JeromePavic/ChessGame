﻿using ChessGame.entities;
using ChessGame.entities.enums;
using ChessGame.logger;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace ChessGame.viewmodels
{
    /// <summary>
    /// Game controller
    /// </summary>
    public class MainGameVM
    {
        private Logger logger;
        private Game game;
        private MainGame mainGame;

        private ChessBoardUserControl chessBoardUC;

        bool moving = false;
        PieceUserControl pieceMoving;
        StackPanel originMoving;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mainGame"></param>
        public MainGameVM(MainGame mainGame)
        {
            logger = new Logger("MainGameVMLogger", LogMode.CURRENT_FOLDER, AlertMode.NONE);
            this.mainGame = mainGame;
            if (this.mainGame.Game != null)
                game = this.mainGame.Game;
            else
                game = new Game("game");

            game.CurrentPlayer = game.Player1;
            InitUC();
            InitActions();

            //TO DELETE
            //this.game.Player1.Help = true;
            //this.game.Player2.Help = true;
        }

        private void InitActions()
        {
            this.mainGame.btnCancelSelect.Click += btnCancelSelect_Click;
            this.mainGame.btnSaveGame.Click += btnSaveGame_Click;
            this.mainGame.btnQuitGame.Click += btnQuitGame_Click;
            foreach (StackPanel stackPanel in chessBoardUC.grid.Children)
            {
                stackPanel.MouseLeftButtonDown += mouseLeftButtonDown;
            }
        }


        /// <summary>
        /// mouseLeftButtonDown : Actions when player clic on the chessboard in the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            int col = Grid.GetColumn(stackPanel);
            int row = Grid.GetRow(stackPanel);
            logger.Log("clic on col=" + col + ", row=" + row + "; stackPanel=" + stackPanel.Name);

            if (!chessBoardUC.ChessBoard.KingInCheck)
            {
                this.mainGame.btnCancelSelect.IsEnabled = true;
            }
            else
            {
                this.mainGame.btnCancelSelect.IsEnabled = false;
            }

            if (!moving && stackPanel.Children.Count == 0)
            {
                return;
            }
            // clic to select a piece...
            else if (!moving && stackPanel.Children.Count > 0)
            {
                pieceMoving = (PieceUserControl)stackPanel.Children[0];
                if (pieceMoving.Piece.Player != game.CurrentPlayer)
                {
                    System.Windows.Forms.MessageBox.Show("This piece is not one of yours!", "Wrong piece",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pieceMoving = null;
                    return;
                }
                stackPanel.Background = Brushes.Green;
                moving = true;
                logger.Log("Piece selected=" + pieceMoving.Piece.Name + ", x=" + pieceMoving.Piece.XPosition + ", y=" + pieceMoving.Piece.YPosition);
                originMoving = stackPanel;

                if (game.CurrentPlayer.Help == true)
                {
                    foreach (StackPanel sp in chessBoardUC.grid.Children)
                    {
                        Case spCase = chessBoardUC.ChessBoard.GetCase(Grid.GetColumn(sp), (7 - Grid.GetRow(sp)));
                        if (chessBoardUC.ChessBoard.MovePossible(pieceMoving.Piece, spCase))
                        {
                            sp.Background = Brushes.Aquamarine;
                        }
                    }
                }

            }
            //clic to move to a case
            else if (moving)
            {
                // if King is moving we check if the case where he's going would not put him in check
                if (pieceMoving.Piece.GetType().Equals(typeof(King)) )
                {
                    //here we have to move the king for real to enable movePossible for a pawn (special case of eating...)
                    Piece tmp = null;
                    if (chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece != null)
                    {
                        tmp = chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece;
                        Piece piece = chessBoardUC.ChessBoard.GetPiece(col, (7 - row));
                        piece.State = State.DEAD;
                    }
                    chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = pieceMoving.Piece;
                    Case spCase = chessBoardUC.ChessBoard.GetCase(Grid.GetColumn(originMoving), (7 - Grid.GetRow(originMoving)));
                    spCase.Piece = null;

                    if (chessBoardUC.ChessBoard.PutKingInCheck(chessBoardUC.ChessBoard.GetCase(col, 7 - row), game.CurrentPlayer))
                    {
                        System.Windows.Forms.MessageBox.Show("You can't move your king to this case, it would be in check!", "Case not allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (tmp != null)
                        {
                            // kind of rollback
                            chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = tmp;
                            Piece piece = chessBoardUC.ChessBoard.GetPiece(col, (7 - row));
                            piece.State = State.ALIVE;
                            tmp = null;
                            spCase.Piece = pieceMoving.Piece;
                        }
                        else
                        {
                            chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = null;
                        }
                        return;
                    }
                    if (tmp != null)
                    {
                        // kind of rollback
                        chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = tmp;
                        Piece piece = chessBoardUC.ChessBoard.GetPiece(col, (7 - row));
                        piece.State = State.ALIVE;
                        tmp = null;
                        spCase.Piece = pieceMoving.Piece;
                    }
                    else
                    {
                        chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = null;
                    }

                }
                if (chessBoardUC.ChessBoard.MovePossible(pieceMoving.Piece, chessBoardUC.ChessBoard.GetCase(col, 7 - row)))
                {
                    if (stackPanel.Children.Count > 0)
                    {
                        PieceUserControl pieceToKill = (PieceUserControl)stackPanel.Children[0];
                        if (chessBoardUC.ChessBoard.Kill(pieceToKill.Piece))
                        {
                            stackPanel.Children.Remove(pieceToKill);
                        }
                    }
                }
                if (chessBoardUC.ChessBoard.Move(pieceMoving.Piece, chessBoardUC.ChessBoard.GetCase(col,7-row)))
                {
                    originMoving.Children.Remove(pieceMoving);
                    stackPanel.Children.Add(pieceMoving);
                    if (pieceMoving.Piece.GetType().Equals(typeof(King)))
                    {
                        if (game.CurrentPlayer == game.Player1)
                        {
                            chessBoardUC.ChessBoard.P1KingCase = chessBoardUC.ChessBoard.GetCase(col, 7 - row);
                        }
                        else
                        {
                            chessBoardUC.ChessBoard.P2KingCase = chessBoardUC.ChessBoard.GetCase(col, 7 - row);
                        }
                    }
                    moving = false;
                    pieceMoving = null;
                    originMoving = null;
                    chessBoardUC.clean(game.Background); // TODO gérer ça comme il faut
                    if (game.CurrentPlayer == game.Player1)
                    {
                        // check if King in check
                        chessBoardUC.ChessBoard.KingInCheck = chessBoardUC.ChessBoard.PutKingInCheck(chessBoardUC.ChessBoard.P2KingCase, game.Player2);
                        if (chessBoardUC.ChessBoard.KingInCheck)
                        {
                            // in case of KingInCheck, we select the other player KingUC for next move
                            StackPanel sP = (StackPanel)chessBoardUC.GetGridElement(chessBoardUC.grid, chessBoardUC.ChessBoard.P2KingCase.XPosition, chessBoardUC.ChessBoard.P2KingCase.YPosition);
                            sP.Background = Brushes.Red;
                            pieceMoving = (PieceUserControl)sP.Children[0];
                            originMoving = sP;
                            moving = true;
                            this.mainGame.btnCancelSelect.IsEnabled = false;
                            bool checkmate = false;
                            foreach (Case caseItem in chessBoardUC.ChessBoard.Cases)
                            {
                                if (chessBoardUC.ChessBoard.MovePossible(pieceMoving.Piece, caseItem))
                                {
                                    checkmate = true;
                                }
                            }
                            if (!checkmate || game.ChessBoard.P2KingCase.Piece == null || game.ChessBoard.P2KingCase.Piece.State ==State.DEAD)
                            {
                                game.Player2.State = State.DEAD;
                                EndGame(game.Player1);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Player 2, your King is in Check", "Player2 King In Check",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                if (game.CurrentPlayer.Help == true)
                                {
                                    foreach (StackPanel sp in chessBoardUC.grid.Children)
                                    {
                                        Case spCase = chessBoardUC.ChessBoard.GetCase(Grid.GetColumn(sp), (7 - Grid.GetRow(sp)));
                                        if (chessBoardUC.ChessBoard.MovePossible(pieceMoving.Piece, spCase))
                                        {
                                            sp.Background = Brushes.Aquamarine;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        chessBoardUC.ChessBoard.KingInCheck = chessBoardUC.ChessBoard.PutKingInCheck(chessBoardUC.ChessBoard.P1KingCase, game.Player1);
                        if (chessBoardUC.ChessBoard.KingInCheck)
                        {
                            // in case of KingInCheck, we select the other player KingUC for next move
                            StackPanel sP = (StackPanel)chessBoardUC.GetGridElement(chessBoardUC.grid, chessBoardUC.ChessBoard.P1KingCase.XPosition, chessBoardUC.ChessBoard.P1KingCase.YPosition);
                            pieceMoving = (PieceUserControl)sP.Children[0];
                            originMoving = sP;
                            moving = true;
                            this.mainGame.btnCancelSelect.IsEnabled = false;
                            bool checkmate = false;
                            foreach (Case caseItem in chessBoardUC.ChessBoard.Cases)
                            {
                                if (chessBoardUC.ChessBoard.MovePossible(pieceMoving.Piece, caseItem))
                                {
                                    checkmate = true;
                                }
                            }
                            if (!checkmate || game.ChessBoard.P1KingCase.Piece == null || game.ChessBoard.P1KingCase.Piece.State == State.DEAD)
                            {
                                game.Player1.State = State.DEAD;
                                EndGame(game.Player2);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Player 1, your King is in Check", "Player1 King In Check",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                if (game.CurrentPlayer.Help == true)
                                {
                                    foreach (StackPanel sp in chessBoardUC.grid.Children)
                                    {
                                        Case spCase = chessBoardUC.ChessBoard.GetCase(Grid.GetColumn(sp), (7 - Grid.GetRow(sp)));
                                        if (chessBoardUC.ChessBoard.MovePossible(pieceMoving.Piece, spCase))
                                        {
                                            sp.Background = Brushes.Aquamarine;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (game.CurrentPlayer == game.Player1)
                {
                    game.CurrentPlayer = game.Player2;
                }
                else
                {
                    game.CurrentPlayer = game.Player1;
                }
                
            }
            
            e.Handled = true;
            
        }

        /// <summary>
        /// End of the game
        /// </summary>
        /// <param name="player1"></param>
        private void EndGame(Player player1)
        {
            System.Windows.Forms.MessageBox.Show("Player 1, your King is in Check", "Player1 King In Check",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Window w = (Window)this.mainGame.Parent;
            w.Close();
        }


        /// <summary>
        /// Initialize user controls
        /// </summary>
        private void InitUC()
        {
            if (this.game.Map != null)
                chessBoardUC = new ChessBoardUserControl(this.game.ChessBoard, this.game.Map.FileName);
            else
                chessBoardUC = new ChessBoardUserControl(this.game.ChessBoard);
            chessBoardUC.Name = "chessBoardUC";
            this.mainGame.mainGrid.Children.Add(chessBoardUC);
            Grid.SetRow(chessBoardUC, 0);
            Grid.SetColumn(chessBoardUC, 0);
            chessBoardUC.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            chessBoardUC.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            chessBoardUC.Load(game.Background, game.Player1.Theme, game.Player2.Theme);

            this.mainGame.lblCurrentPlayer.Content = this.game.CurrentPlayer.Name;
        }

        /// <summary>
        /// Cancel a piece selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelSelect_Click(object sender, RoutedEventArgs e)
        {
            if (pieceMoving != null)
            {
                moving = false;
                pieceMoving = null;
                originMoving = null;
                this.chessBoardUC.clean(game.Background);
            }            
        }


        /// <summary>
        /// Quit the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuitGame_Click(object sender, RoutedEventArgs e)
        {
            Window w = (Window)this.mainGame.Parent;
            w.Close();
        }

        /// <summary>
        /// Save the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Saving will be soon available", "Not available",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
            //ChessBoardUserControl test = Utils.FindChild<ChessBoardUserControl>(this.mainGame, "chessBoardUC");
            //StackPanel stackPanel = (StackPanel)test.GetGridElement(test.grid, test.ChessBoard.Pieces[5].XPosition, test.ChessBoard.Pieces[5].YPosition);
            //PieceUserControl pp = (PieceUserControl)stackPanel.Children[0];
            //stackPanel.Children.Remove(pp);
            //StackPanel stackPane2 = (StackPanel)test.GetGridElement(test.grid, 4, 2);
            //test.grid.Children.Remove(stackPane2);
            //stackPane2.Children.Add(pp);
            //test.grid.Children.Add(stackPane2);
            //Grid.SetRow(stackPane2, 4);
            //Grid.SetColumn(stackPane2, 2);
        }



    }
}
