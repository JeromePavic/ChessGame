using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Player
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private Rook rookLeft;
        public Rook RookLeft
        {
            get { return rookLeft; }
            set { rookLeft = value; }
        }

        private Rook rookRight;

        public Rook RookRight
        {
            get { return rookRight; }
            set { rookRight = value; }
        }





    }
}
