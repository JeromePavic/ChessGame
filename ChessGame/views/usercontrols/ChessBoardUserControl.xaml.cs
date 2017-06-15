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
            var whiteBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            var blackBrush = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            if (background)
            {
                whiteBrush.Opacity = 0.3;
                blackBrush.Opacity = 0.3;
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    StackPanel stackPanel = new StackPanel();
                    
                    if (row % 2 == 1)
                    {
                        if (col % 2 == 1)
                            stackPanel.Background = whiteBrush;
                        else
                            stackPanel.Background = blackBrush;
                    }
                    else
                    {
                        if (col % 2 == 1)
                            stackPanel.Background = blackBrush;
                        else
                            stackPanel.Background = whiteBrush;
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
                if (pieceUC.Piece.Name.Contains("p1"))
                {
                    pieceUC.LoadImg();//TODO charger le theme
                }
                else
                {
                    pieceUC.LoadImg();//TODO charger le theme
                }

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
            var whiteBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            var blackBrush = new SolidColorBrush(Color.FromRgb(50, 50, 50));
            if (background)
            {
                whiteBrush.Opacity = 0.3;
                blackBrush.Opacity = 0.3;
            }

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    StackPanel stackPanel = (StackPanel)this.GetGridElement(grid, col, row);
                    if (row % 2 == 1)
                    {
                        if (col % 2 == 1)
                            stackPanel.Background = blackBrush;
                        else
                            stackPanel.Background = whiteBrush;
                    }
                    else
                    {
                        if (col % 2 == 1)
                            stackPanel.Background = whiteBrush;
                        else
                            stackPanel.Background = blackBrush;
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
