using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Pawn : Piece
    {
        //Conditions to allow move to the case pCase
        public override bool MoveOK(Case pCase)
        {
            int xCurrent = this.XPosition;
            int yCurrent = this.YPosition;

            if ((pCase.XPosition == xCurrent && pCase.YPosition == yCurrent + 1 && pCase.Piece == null) ||
                (pCase.XPosition == xCurrent && pCase.YPosition == yCurrent + 2 && pCase.Piece == null && MvCount==0) ||
                (pCase.XPosition == xCurrent + 1 && pCase.YPosition == yCurrent + 1 && pCase.Piece != null && pCase.Piece.Player != Player) ||
                (pCase.XPosition == xCurrent - 1 && pCase.YPosition == yCurrent + 1 && pCase.Piece != null && pCase.Piece.Player != Player))
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
