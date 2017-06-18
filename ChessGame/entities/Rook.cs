using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    /// <summary>
    /// Represent the chess element : Rook
    /// </summary>
    public class Rook : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Rook()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pX">column value</param>
        /// <param name="pY">row value</param>
        public Rook(Int32 pX, Int32 pY)
        {
            this.XPosition = pX;
            this.YPosition = pY;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pX">column value</param>
        /// <param name="pY">row value</param>
        /// <param name="pName">Piece name</param>
        /// <param name="pCase">Piece case on chessboard</param>
        public Rook(Int32 pX, Int32 pY, String pName, Case pCase)
        {
            this.XPosition = pX;
            this.YPosition = pY;
            this.CurrentCase = pCase;
            this.Name = pName;
            this.State = State.ALIVE;
            this.MvCount = 0;
        }

        /// <summary>
        /// MoveOK : tells is the current piece can move to the case pCase
        /// </summary>
        /// <param name="pCase">case to test</param>
        /// <returns>true if possible, otherwise false</returns>
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
