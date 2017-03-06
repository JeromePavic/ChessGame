using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Piece : Element
    {
        private Int32 xPositionNext;
        public Int32 XPositionNext
        {
            get { return xPositionNext; }
            set { xPositionNext = value; }
        }

        private Int32 yPositionNext;
        public Int32 YPositionNext
        {
            get { return yPositionNext; }
            set { yPositionNext = value; }
        }

        private State status;
        public State Status
        {
            get { return alive; }
            set { alive = value; }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }





    }
}
