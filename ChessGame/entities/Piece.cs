using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public abstract class Piece : Element
    {

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

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

        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private Int32 mvCount;
        public Int32 MvCount
        {
            get { return mvCount; }
            set { mvCount = value; }
        }

        private Case currentCase;
        public Case CurrentCase
        {
            get { return currentCase; }
            set { currentCase = value; }
        }

        public bool CaseAllowed(Case pCase)
        {
            if (pCase.Piece == null || pCase.Piece.Color != Color)
            {
                return true;
            }
            return false;
        }

        public abstract Boolean MoveOK(Case pCase);
    }
}
