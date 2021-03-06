﻿using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    /// <summary>
    /// Represent the chess element : Pawn
    /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pX">column value</param>
        /// <param name="pY">row value</param>
        /// <param name="pName">Piece name</param>
        /// <param name="pCase">Piece case on chessboard</param>
        public Pawn(Int32 pX, Int32 pY, String pName, Case pCase)
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
