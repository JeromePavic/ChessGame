using ChessGame.entities;
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
    public class MainGameVM
    {
        private Logger logger;
        private Game game;
        private MainGame mainGame;

        private ChessBoardUserControl chessBoardUC;

        bool moving = false;
        PieceUserControl pieceMoving;
        StackPanel originMoving;

        public MainGameVM(MainGame mainGame)
        {
            logger = new Logger("MainGameVMLogger", LogMode.CURRENT_FOLDER, AlertMode.NONE);
            this.mainGame = mainGame;
            game = new Game("game");
            InitUC();
            InitActions();

            //TO DELETE
            this.game.Player1.Help = true;
            this.game.Player2.Help = true;
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
                    }
                    chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = pieceMoving.Piece;
                    if (chessBoardUC.ChessBoard.PutKingInCheck(chessBoardUC.ChessBoard.GetCase(col, 7 - row), game.CurrentPlayer))
                    {
                        System.Windows.Forms.MessageBox.Show("You can't move your king to this case, it would be in check!", "Case not allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (tmp != null)
                        {
                            // kind of rollback
                            chessBoardUC.ChessBoard.GetCase(col, 7 - row).Piece = tmp;
                            tmp = null;
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
                        tmp = null;
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
                    chessBoardUC.clean(true); // TODO gérer ça comme il faut
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
                            if (!checkmate)
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
                            if (!checkmate)
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

        private void EndGame(Player player1)
        {
            throw new NotImplementedException();
        }

        private void InitUC()
        {

            chessBoardUC = new ChessBoardUserControl(this.game.ChessBoard, "C:\\Users\\jerome\\Pictures\\photo_gamelle_couv.jpg");
            chessBoardUC.Name = "chessBoardUC";
            this.mainGame.mainGrid.Children.Add(chessBoardUC);
            Grid.SetRow(chessBoardUC, 0);
            Grid.SetColumn(chessBoardUC, 1);
            chessBoardUC.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            chessBoardUC.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            chessBoardUC.Load(true); //TODO gérer le vrai paramètre
        }


        private void btnCancelSelect_Click(object sender, RoutedEventArgs e)
        {
            if (pieceMoving != null)
            {
                moving = false;
                pieceMoving = null;
                originMoving = null;
            }            
        }

        private void btnQuitGame_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            ChessBoardUserControl test = Utils.FindChild<ChessBoardUserControl>(this.mainGame, "chessBoardUC");
            StackPanel stackPanel = (StackPanel)test.GetGridElement(test.grid, test.ChessBoard.Pieces[5].XPosition, test.ChessBoard.Pieces[5].YPosition);
            PieceUserControl pp = (PieceUserControl)stackPanel.Children[0];
            stackPanel.Children.Remove(pp);
            StackPanel stackPane2 = (StackPanel)test.GetGridElement(test.grid, 4, 2);
            test.grid.Children.Remove(stackPane2);
            stackPane2.Children.Add(pp);
            test.grid.Children.Add(stackPane2);
            Grid.SetRow(stackPane2, 4);
            Grid.SetColumn(stackPane2, 2);
        }



        //public void getPosition(UIElement element, out int col, out int row)
        //{
        //    Grid control = element.parent as DControl;
        //    var point = Mouse.GetPosition(element);
        //    row = 0;
        //    col = 0;
        //    double accumulatedHeight = 0.0;
        //    double accumulatedWidth = 0.0;

        //    // calc row mouse was over
        //    foreach (var rowDefinition in control.RowDefinitions)
        //    {
        //        accumulatedHeight += rowDefinition.ActualHeight;
        //        if (accumulatedHeight >= point.Y)
        //            break;
        //        row++;
        //    }

        //    // calc col mouse was over
        //    foreach (var columnDefinition in control.ColumnDefinitions)
        //    {
        //        accumulatedWidth += columnDefinition.ActualWidth;
        //        if (accumulatedWidth >= point.X)
        //            break;
        //        col++;
        //    }
        //}

        //public void updatePosition()
        //{
        //    Grid.SetRow(this, (int)position.Y);
        //    Grid.SetColumn(this, (int)position.X);
        //    Margin = new Thickness();
        //}



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
