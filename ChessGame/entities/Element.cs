using ChessGame.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public abstract class Element : BaseDBEntity
    {
        private Int32 xPosition;
        public Int32 XPosition
        {
            get { return xPosition; }
            set { xPosition = value; }
        }

        private Int32 yPosition;
        public Int32 YPosition
        {
            get { return yPosition; }
            set { yPosition = value; }
        }


    }
}
