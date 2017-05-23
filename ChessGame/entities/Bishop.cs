using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Bishop : Piece
    {
        public Bishop()
        {
        }

        public Bishop(Int32 pX, Int32 pY)
        {
            this.XPosition = pX;
            this.YPosition = pY;
        }

        public Bishop(Int32 pX, Int32 pY, String pName, Case pCase)
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
            int xCurrent = 0;
            int yCurrent = 0;

            if (((pCase.XPosition - xCurrent) == (pCase.YPosition - yCurrent) ||
                (pCase.XPosition - xCurrent) == -(pCase.YPosition - yCurrent))
                && CaseAllowed(pCase))
            {
                return true;
            }
            return false;

        }
    }
}
