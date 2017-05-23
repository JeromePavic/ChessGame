using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Case : Element
    {
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
