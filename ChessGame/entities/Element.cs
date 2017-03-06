using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Element
    {
        private int xPosition;
        public int XPosition
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        private int yPosition;

        public int YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }


    }
}
