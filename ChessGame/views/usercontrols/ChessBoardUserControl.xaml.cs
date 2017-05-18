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
    public partial class ChessBoardUserControl : UserControl
    {
        public ChessBoardUserControl()
        {
            InitializeComponent();

            ////gris creation (9*9)
            //Grid grid = new Grid {/* Width = 300, Height = 400 */};
            //for (int i = 0; i < 10; i++)
            //{
            //    grid.RowDefinitions.Add(new RowDefinition());
            //    grid.ColumnDefinitions.Add(new ColumnDefinition());
            //}
            
            //this.Content = grid;

            //Grid.SetRow(new CaseUserControl(), 0);
            //grid.SetColumn(someLabel, 0);
        }
    }
}
