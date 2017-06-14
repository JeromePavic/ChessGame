using ChessGame.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour ListThemeUserControl.xaml
    /// </summary>
    public partial class ListThemeUserControl : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Theme> Obs { get; set; }


        public ListThemeUserControl()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Theme>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Theme> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Theme item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Theme item)
        {
            Obs.Remove(item);
        }
    }
}
