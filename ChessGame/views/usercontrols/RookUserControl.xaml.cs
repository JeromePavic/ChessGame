﻿using ChessGame.entities;
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
    /// Logique d'interaction pour RookUserControl.xaml
    /// </summary>
    public partial class RookUserControl : UserControlBase
    {
        private Rook rook;
        public Rook Rook
        {
            get { return rook; }
            set
            {
                rook = value;
                base.OnPropertyChanged("Rook");
            }
        }

        public RookUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
