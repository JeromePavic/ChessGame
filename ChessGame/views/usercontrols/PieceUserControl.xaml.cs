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
    /// Logique d'interaction pour PieceUserControl.xaml
    /// </summary>
    public partial class PieceUserControl : UserControlBase
    {
        private Piece piece;
        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                base.OnPropertyChanged("Piece");
            }
        }

        public PieceUserControl()
        {
            InitializeComponent();
            base.DataContext = this;

            
        }

        internal void LoadImg()
        {
            var imgBrush = new ImageBrush();
            if (this.piece.GetType() == typeof(Pawn))
            {
                if (this.piece.Name.Contains("p1"))
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["WhitePawn"];
                else
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["BlackPawn"];
            }
            else if (this.piece.GetType() == typeof(Rook))
            {
                if (this.piece.Name.Contains("p1"))
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["WhiteRook"];
                else
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["BlackRook"];
            }
            else if (this.piece.GetType() == typeof(Knight))
            {
                if (this.piece.Name.Contains("p1"))
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["WhiteKnight"];
                else
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["BlackKnight"];
            }
            else if (this.piece.GetType() == typeof(Bishop))
            {
                if (this.piece.Name.Contains("p1"))
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["WhiteBishop"];
                else
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["BlackBishop"];
            }
            else if (this.piece.GetType() == typeof(Queen))
            {
                if (this.piece.Name.Contains("p1"))
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["WhiteQueen"];
                else
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["BlackQueen"];
            }
            else if (this.piece.GetType() == typeof(King))
            {
                if (this.piece.Name.Contains("p1"))
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["WhiteKing"];
                else
                    imgBrush.ImageSource = (BitmapImage)Application.Current.Resources["BlackKing"];
            }




            Rectangle rect = new Rectangle();
            rect.Height = 40;
            rect.Width = 40;
            rect.Fill = imgBrush;

            Canvas.SetLeft(rect,0);
            Canvas.SetTop(rect, 0);

            canvas.Children.Add(rect);

        }


        internal void LoadImg(Theme pTheme)
        {
            var imgBrush = new ImageBrush();
            if (this.piece.GetType() == typeof(Pawn))
            {
                Uri uri = new Uri(pTheme.PawnFileName);
                BitmapImage img = new BitmapImage(uri);
                imgBrush.ImageSource = img;
            }
            else if (this.piece.GetType() == typeof(Rook))
            {
                Uri uri = new Uri(pTheme.RookFileName);
                BitmapImage img = new BitmapImage(uri);
                imgBrush.ImageSource = img;
            }
            else if (this.piece.GetType() == typeof(Knight))
            {
                Uri uri = new Uri(pTheme.KnightFileName);
                BitmapImage img = new BitmapImage(uri);
                imgBrush.ImageSource = img;
            }
            else if (this.piece.GetType() == typeof(Bishop))
            {
                Uri uri = new Uri(pTheme.BishopFileName);
                BitmapImage img = new BitmapImage(uri);
                imgBrush.ImageSource = img;
            }
            else if (this.piece.GetType() == typeof(Queen))
            {
                Uri uri = new Uri(pTheme.QueenFileName);
                BitmapImage img = new BitmapImage(uri);
                imgBrush.ImageSource = img;
            }
            else if (this.piece.GetType() == typeof(King))
            {
                Uri uri = new Uri(pTheme.KingFileName);
                BitmapImage img = new BitmapImage(uri);
                imgBrush.ImageSource = img;
            }




            Rectangle rect = new Rectangle();
            rect.Height = 40;
            rect.Width = 40;
            rect.Fill = imgBrush;

            Canvas.SetLeft(rect, 0);
            Canvas.SetTop(rect, 0);

            canvas.Children.Add(rect);

        }
    }
}
