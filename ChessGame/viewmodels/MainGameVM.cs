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

        private ChessBoardUserControl chessBoardUC;

        bool moving = false;
        PawnUserControl pieceMoving;
        StackPanel originMoving;

        public MainGameVM(MainGame mainGame)
        {
            this.mainGame = mainGame;
            game = new Game("game");
            InitUC();
            InitActions();
        }

        private void InitActions()
        {
            this.mainGame.btnCancelSelect.Click += btnCancelSelect_Click;
            this.mainGame.btnSaveGame.Click += btnSaveGame_Click;
            this.mainGame.btnQuitGame.Click += btnQuitGame_Click;
            foreach (StackPanel stackPanel in chessBoardUC.grid.Children)
            {
                stackPanel.MouseLeftButtonDown += mouseLeftButtonDown;
                //stackPanel.MouseLeftButtonUp += mouseLeftButtonUp;
                //stackPanel.MouseMove += mouseMove;
            }
        }

        

        public void mouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)sender;
            int row = Grid.GetRow(stackPanel);
            int col = Grid.GetColumn(stackPanel);
            if (!moving && stackPanel.Children.Count == 0)
            {
                return;
            }
            else if (!moving && stackPanel.Children.Count > 0)
            {   
                stackPanel.Background = Brushes.Green;
                //Console.WriteLine("Row: " + row + " Column: " + col);

                moving = true;
                pieceMoving = (PawnUserControl)stackPanel.Children[0];
                originMoving = stackPanel;

            }
            else if (pieceMoving != null)
            {
                stackPanel.Background = Brushes.Red;
                originMoving.Children.Remove(pieceMoving);
                stackPanel.Children.Add(pieceMoving);

                moving = false;
                pieceMoving = null;
                originMoving = null;
            }
                
            e.Handled = true;
            
        }

      

        private void InitUC()
        {

            chessBoardUC = new ChessBoardUserControl(this.game.ChessBoard);
            chessBoardUC.Name = "chessBoardUC";
            this.mainGame.mainGrid.Children.Add(chessBoardUC);
            Grid.SetRow(chessBoardUC, 0);
            Grid.SetColumn(chessBoardUC, 1);
            chessBoardUC.VerticalAlignment = VerticalAlignment.Stretch;
            chessBoardUC.HorizontalAlignment = HorizontalAlignment.Stretch;
            chessBoardUC.Load();
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
            PawnUserControl pp = (PawnUserControl)stackPanel.Children[0];
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
