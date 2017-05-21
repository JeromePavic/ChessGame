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
    /// Logique d'interaction pour CaseWhiteUserControl.xaml
    /// </summary>
    public partial class CaseWhiteUserControl : UserControlBase
    {
        private Case caseWhite;
        public Case CaseWhite
        {
            get { return caseWhite; }
            set
            {
                caseWhite = value;
                base.OnPropertyChanged("Case");
            }
        }

        public CaseWhiteUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
