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
    /// Logique d'interaction pour KnightUserControl.xaml
    /// </summary>
    public partial class KnightUserControl : UserControlBase
    {
        private Knight knight;
        public Knight Knight
        {
            get { return knight; }
            set
            {
                knight = value;
                base.OnPropertyChanged("Knight");
            }
        }
        public KnightUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
