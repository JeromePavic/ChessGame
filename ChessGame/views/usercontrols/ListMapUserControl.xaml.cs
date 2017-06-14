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
    /// Logique d'interaction pour ListMapUserControl.xaml
    /// </summary>
    public partial class ListMapUserControl : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Map> Obs { get; set; }


        public ListMapUserControl()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Map>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Map> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Map item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Map item)
        {
            Obs.Remove(item);
        }
    }
}
