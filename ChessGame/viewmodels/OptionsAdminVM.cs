using ChessGame.views.administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ChessGame.viewmodels
{
    public class OptionsAdminVM
    {
        private OptionsAdmin optionsAdmin;

        public OptionsAdminVM(OptionsAdmin optionsAdmin)
        {
            this.optionsAdmin = optionsAdmin;

            InitUC();
            InitLUC();
            InitActions();
        }

        private void InitActions()
        {
            this.optionsAdmin.btnOk.Click += btnOk_Click;
            optionsAdmin.ColorsList = new List<Brush>()
                {
                Brushes.Azure,
                Brushes.ForestGreen,
                Brushes.IndianRed,
                Brushes.White,
                Brushes.Black
                };

        }

        private void InitLUC()
        {
           
        }

        private void InitUC()
        {

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.optionsAdmin.NavigationService.GoBack();
        }
    }
}
