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

        public Case At(Int32 x, Int32 y)
        {
            if (x == XPosition && y == YPosition)
                return true;

        }

    }
}
