﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChessGame.entities.bases
{
    /// <summary>
    /// BaseDBEntity : Base class for Id inheritance 
    /// </summary>
    public class BaseDBEntity : BaseEntity
    {
        private Int32 id;

        public Int32 Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
    }
}
