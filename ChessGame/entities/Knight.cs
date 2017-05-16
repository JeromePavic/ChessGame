using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Knight : Piece
    {

        public override bool MoveOK(Case pCase)
        {
            int xOrigin = 0;
            int yOrigin = 0;

            if ((pCase.YPosition == yOrigin + 2 && pCase.XPosition == xOrigin - 1) ||
                (pCase.YPosition == yOrigin + 2 && pCase.XPosition == xOrigin + 1) ||
                (pCase.YPosition == yOrigin + 1 && pCase.XPosition == xOrigin + 2) ||
                (pCase.YPosition == yOrigin - 1 && pCase.XPosition == xOrigin + 2) ||
                (pCase.YPosition == yOrigin - 2 && pCase.XPosition == xOrigin + 1) ||
                (pCase.YPosition == yOrigin - 2 && pCase.XPosition == xOrigin - 1) ||
                (pCase.YPosition == yOrigin - 1 && pCase.XPosition == xOrigin - 2) ||
                (pCase.YPosition == yOrigin + 1 && pCase.XPosition == xOrigin - 2) )
            {
                return true;
            }
            return false;

        }

    }
}
