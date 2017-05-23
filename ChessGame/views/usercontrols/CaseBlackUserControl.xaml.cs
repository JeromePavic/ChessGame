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
    /// Logique d'interaction pour CaseBlackUserControl.xaml
    /// </summary>
    public partial class CaseBlackUserControl : UserControlBase
    {
        private Case caseBlack;
        public Case CaseBlack
        {
            get { return caseBlack; }
            set
            {
                caseBlack = value;
                base.OnPropertyChanged("Case");
            }
        }

        public CaseBlackUserControl()
        {
            InitializeComponent();
            this.AllowDrop = true;
            base.DataContext = this;
        }

        private void OnDesignerDragOver()
        {

        }
    }
}
