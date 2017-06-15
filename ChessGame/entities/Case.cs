using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public class Case : Element
    {
        //[Key, ForeignKey("Piece")]
        //public new Int32 Id
        //{
        //    get { return base.Id; }
        //    set { base.Id = value; OnPropertyChanged("Id"); }
        //}

        public Case()
        {
        }

        public Case(Int32 pX, Int32 pY)
        {
            this.XPosition = pX;
            this.YPosition = pY;
        }

        private Availability available;
        public Availability Available
        {
            get { return available; }
            set { available = value; }
        }

        private Piece piece;
        public Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }


    }
}
