using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Knight : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Knight()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pX">column value</param>
        /// <param name="pY">row value</param>
        public Knight(Int32 pX, Int32 pY)
        {
            this.XPosition = pX;
            this.YPosition = pY;
        }

        public Knight(Int32 pX, Int32 pY, String pName, Case pCase)
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
            int xOrigin = this.XPosition; ;
            int yOrigin = this.YPosition; ;

            if (((pCase.YPosition == yOrigin + 2 && pCase.XPosition == xOrigin - 1) ||
                (pCase.YPosition == yOrigin + 2 && pCase.XPosition == xOrigin + 1) ||
                (pCase.YPosition == yOrigin + 1 && pCase.XPosition == xOrigin + 2) ||
                (pCase.YPosition == yOrigin - 1 && pCase.XPosition == xOrigin + 2) ||
                (pCase.YPosition == yOrigin - 2 && pCase.XPosition == xOrigin + 1) ||
                (pCase.YPosition == yOrigin - 2 && pCase.XPosition == xOrigin - 1) ||
                (pCase.YPosition == yOrigin - 1 && pCase.XPosition == xOrigin - 2) ||
                (pCase.YPosition == yOrigin + 1 && pCase.XPosition == xOrigin - 2) )
                && CaseAllowed(pCase))
            {
                return true;
            }
            return false;

        }

    }
}
