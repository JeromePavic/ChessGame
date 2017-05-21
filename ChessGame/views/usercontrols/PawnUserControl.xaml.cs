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
    /// Logique d'interaction pour PawnUserControl.xaml
    /// </summary>
    public partial class PawnUserControl : UserControlBase
    {
        private Pawn pawn;
        public Pawn Pawn
        {
            get { return pawn; }
            set
            {
                pawn = value;
                base.OnPropertyChanged("Pawn");
            }
        }

        public PawnUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
