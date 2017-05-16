using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Rook : Piece
    {

        public override bool MoveOK(Case pCase)
        {
            Int32 xCurrent = this.XPosition;
            Int32 yCurrent = this.YPosition;

            if ((pCase.XPosition == xCurrent || pCase.YPosition == yCurrent) && CaseAllowed(pCase))
            {
                return true;
            }
            return false;
        }


    }
}
