using ChessGame.entities;
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

namespace ChessGame.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour ChessBoardUserControl.xaml
    /// </summary>
    public partial class ChessBoardUserControl : UserControlBase
    {
        private ChessBoard chessBoard;
        public ChessBoard ChessBoard
        {
            get { return chessBoard; }
            set
            {
                chessBoard = value;
                base.OnPropertyChanged("ChessBoard");
            }
        }

        public ChessBoardUserControl(ChessBoard pChessBoard)
        {
            this.ChessBoard = pChessBoard;
            InitializeComponent();
            InitGrid();
            InitPieces();
            base.DataContext = this;
        }

        private void InitGrid()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    StackPanel stackPanel = new StackPanel();
                    if (row % 2 == 1)
                    {
                        if (col % 2 == 1)
                            stackPanel.Background = Brushes.White;
                        else
                            stackPanel.Background = Brushes.Black;
                    }
                    else
                    {
                        if (col % 2 == 1)
                            stackPanel.Background = Brushes.Black;
                        else
                            stackPanel.Background = Brushes.White;
                    }
                    Grid.SetRow(stackPanel, row);
                    Grid.SetColumn(stackPanel, col);
                    grid.Children.Add(stackPanel);
                }
            }
        }


        private void InitPieces()
        {
            foreach (var pieceItem in ChessBoard.Pieces)
            {
                StackPanel stackPanel = (StackPanel)GetGridElement(grid, pieceItem.XPosition, pieceItem.YPosition);
                PawnUserControl pieceUC = new PawnUserControl();
                pieceUC.HorizontalAlignment = HorizontalAlignment.Center;
                pieceUC.VerticalAlignment = VerticalAlignment.Center;
                pieceUC.Name = pieceItem.Name + "UC";
                stackPanel.Children.Add(pieceUC);
            }
        }


        public UIElement GetGridElement(Grid g, int r, int c)
        {
            for (int i = 0; i < g.Children.Count; i++)
            {
                UIElement e = g.Children[i];
                if (Grid.GetRow(e) == r && Grid.GetColumn(e) == c)
                    return e;
            }
            return null;
        }
    }

}
