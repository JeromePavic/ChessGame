using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class King : Piece
    {

        public override bool MoveOK(Case pCase)
        {
            Int32 xCurrent = this.XPosition;
            Int32 yCurrent = this.YPosition;

            if (((pCase.YPosition == yCurrent + 1 && (pCase.XPosition == xCurrent || pCase.XPosition == xCurrent + 1 || pCase.XPosition == xCurrent - 1)) ||
                (pCase.YPosition == yCurrent - 1 && (pCase.XPosition == xCurrent || pCase.XPosition == xCurrent + 1 || pCase.XPosition == xCurrent - 1)) ||
                (pCase.YPosition == yCurrent && (pCase.XPosition == xCurrent || pCase.XPosition == xCurrent + 1 || pCase.XPosition == xCurrent - 1)) )
                && CaseAllowed(pCase))
            {
                return true;
            }
            return false;
        }

    }
}
