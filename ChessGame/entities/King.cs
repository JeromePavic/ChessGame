using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class King : Piece
    {
        public King()
        {
        }

        public King(Int32 pX, Int32 pY)
        {
            this.XPosition = pX;
            this.YPosition = pY;
        }

        public King(Int32 pX, Int32 pY, String pName, Case pCase)
        {
            this.XPosition = pX;
            this.YPosition = pY;
            this.CurrentCase = pCase;
            this.Name = pName;
            this.State = State.ALIVE;
            this.MvCount = 0;
        }


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
