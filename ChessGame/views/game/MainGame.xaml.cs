using ChessGame.entities;
using ChessGame.viewmodels;
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

namespace ChessGame.views.game
{
    /// <summary>
    /// Logique d'interaction pour MainGame.xaml
    /// </summary>
    public partial class MainGame : Page
    {
        public Game Game { get; set; }

        public MainGame()
        {
            InitializeComponent();
            this.DataContext = new MainGameVM(this);
        }

        public MainGame(Game pGame)
        {
            this.Game = pGame;
            InitializeComponent();
            this.DataContext = new MainGameVM(this);
        }

    }
}
