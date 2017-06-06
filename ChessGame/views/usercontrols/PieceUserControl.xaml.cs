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
    /// Logique d'interaction pour PieceUserControl.xaml
    /// </summary>
    public partial class PieceUserControl : UserControlBase
    {
        private Piece piece;
        public Piece Piece
        {
            get { return piece; }
            set
            {
                piece = value;
                base.OnPropertyChanged("Piece");
            }
        }

        public PieceUserControl()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
