using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Bishop : Piece
    {
        public override bool Move(Case pCase)
        {
            int xOrigin = 0;
            int yOrigin = 0;

            if ((((pCase.XPosition - xOrigin) == (pCase.YPosition - yOrigin) || (pCase.XPosition - xOrigin) == -(pCase.YPosition - yOrigin)) 
                &&
                (for (int i = 0, j = 0; i+xOrigin <= pCase.XPosition && j + yOrigin <= pCase.YPosition; i++, j++)
                {

                })
            pCase.Piece == null)
                ||
                (pCase.XPosition == xOrigin && pCase.YPosition == yOrigin + 2 && pCase.Piece == null && !Moved)
                ||
                (pCase.XPosition == xOrigin + 1 && pCase.YPosition == yOrigin + 1 && pCase.Piece != null && pCase.Piece.Color != Color)
                )
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
