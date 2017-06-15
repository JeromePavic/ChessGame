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

namespace ChessGame.views.administration
{
    /// <summary>
    /// Logique d'interaction pour OptionsAdmin.xaml
    /// </summary>
    public partial class OptionsAdmin : Page
    {

        public OptionsAdmin()
        {
            InitializeComponent();
            this.DataContext = new OptionsAdminVM(this);

        }

        
    }
}
