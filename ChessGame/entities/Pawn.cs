using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Pawn : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Pawn()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pX">column value</param>
        /// <param name="pY">row value</param>
        public Pawn(Int32 pX, Int32 pY)
        {
            this.XPosition = pX;
            this.YPosition = pY;
        }

        public Pawn(Int32 pX, Int32 pY, String pName, Case pCase)
        {
            this.XPosition = pX;
            this.YPosition = pY;
            this.CurrentCase = pCase;
            this.Name = pName;
            this.State = State.ALIVE;
            this.MvCount = 0;
        }


        //Conditions to allow move to the case pCase
        public override bool MoveOK(Case pCase)
        {
            int xCurrent = this.XPosition;
            int yCurrent = this.YPosition;

            if (this.Player.White == true)
            {
                if ((pCase.XPosition == xCurrent && pCase.YPosition == yCurrent + 1 && pCase.Piece == null) ||
                (pCase.XPosition == xCurrent && pCase.YPosition == yCurrent + 2 && pCase.Piece == null && MvCount == 0) ||
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
            else
            {
                if ((pCase.XPosition == xCurrent && pCase.YPosition == yCurrent - 1 && pCase.Piece == null) ||
                (pCase.XPosition == xCurrent && pCase.YPosition == yCurrent - 2 && pCase.Piece == null && MvCount == 0) ||
                (pCase.XPosition == xCurrent + 1 && pCase.YPosition == yCurrent - 1 && pCase.Piece != null && pCase.Piece.Player != Player) ||
                (pCase.XPosition == xCurrent - 1 && pCase.YPosition == yCurrent - 1 && pCase.Piece != null && pCase.Piece.Player != Player))
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
}
