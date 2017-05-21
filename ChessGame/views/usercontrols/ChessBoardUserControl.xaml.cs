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

        public ChessBoardUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
