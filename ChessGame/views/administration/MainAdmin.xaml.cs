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

namespace ChessGame.views.administration
{
    /// <summary>
    /// Logique d'interaction pour MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Page
    {
        public MainAdmin()
        {
            InitializeComponent();
            this.DataContext = new MainAdminVM(this);
        }

    }
}
