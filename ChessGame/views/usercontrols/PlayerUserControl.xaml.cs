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
    /// Logique d'interaction pour PlayerUserControl.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControlBase
    {
        private Player player;
        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                base.OnPropertyChanged("Player");
            }
        }

        public PlayerUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
