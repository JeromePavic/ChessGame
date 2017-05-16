using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Bishop : Piece
    {

        public override bool MoveOK(Case pCase)
        {
            int xCurrent = 0;
            int yCurrent = 0;

            if ((pCase.XPosition - xCurrent) == (pCase.YPosition - yCurrent) ||
                (pCase.XPosition - xCurrent) == -(pCase.YPosition - yCurrent)) 
            {
                return true;
            }
            return false;

        }
    }
}
