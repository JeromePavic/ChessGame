using ChessGame.entities;
using ChessGame.viewmodels;
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

namespace ChessGame.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour ChessBoardUserControl.xaml
    /// </summary>
    public partial class ChessBoardUserControl : UserControlBase
    {
        private ImageBrush background;
        public ImageBrush BackGround
        {
            get { return background; }
            set { background = value; }
        }


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
            base.DataContext = this;
        }

        public ChessBoardUserControl(ChessBoard pChessBoard, String ImgUri)
        {
            this.ChessBoard = pChessBoard;
            InitializeComponent();
            base.DataContext = this;
            LoadBackground(ImgUri);
        }

        private void LoadBackground(string imgUri)
        {
            background = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(imgUri));
            background.ImageSource = image.Source;
            grid.Background = background;
        }

        private void InitGrid(bool background)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    StackPanel stackPanel = new StackPanel();
                    if (!background)
                    {
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
                    }

                    
                    stackPanel.Name = "SP" + col + (7-row);
                    Grid.SetColumn(stackPanel, col);
                    Grid.SetRow(stackPanel, row);
                    grid.Children.Add(stackPanel);
                    
                }
            }
        }


        private void InitPieces()
        {
            foreach (var pieceItem in ChessBoard.Pieces)
            {
                // get current MainGame VM object
                //Grid mainGrid = (Grid)this.Parent;
                //MainGame mainGame = (MainGame)mainGrid.Parent;
                //MainGameVM mainGameVM = (MainGameVM)mainGame.DataContext;

                StackPanel stackPanel = (StackPanel)GetGridElement(grid, pieceItem.XPosition, pieceItem.YPosition);
                PieceUserControl pieceUC = new PieceUserControl();
                pieceUC.Piece = pieceItem;
                pieceUC.LoadImg();
                pieceUC.HorizontalAlignment = HorizontalAlignment.Center;
                pieceUC.VerticalAlignment = VerticalAlignment.Center;
                pieceUC.Name = pieceItem.Name + "UC";
                stackPanel.Children.Add(pieceUC);
            }
        }

        public void Load(bool background)
        {
            InitGrid(background);
            InitPieces();
        }

        public void clean(bool background)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    StackPanel stackPanel = (StackPanel)this.GetGridElement(grid, col, row);
                    if (!background)
                    {
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
                    }
                    else
                    {
                        stackPanel.Background = Brushes.Transparent;
                    }

                }
            }
        }

        public UIElement GetGridElement(Grid g, int c, int r)
        {
            for (int i = 0; i < g.Children.Count; i++)
            {
                UIElement e = g.Children[i];
                if (Grid.GetRow(e) == (7-r) && Grid.GetColumn(e) == (c))
                    return e;
            }
            return null;
        }
    }

}
