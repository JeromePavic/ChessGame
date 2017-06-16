using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public abstract class Piece : Element
    {

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Int32 xPositionNext;
        public Int32 XPositionNext
        {
            get { return xPositionNext; }
            set { xPositionNext = value; }
        }

        private Int32 yPositionNext;
        public Int32 YPositionNext
        {
            get { return yPositionNext; }
            set { yPositionNext = value; }
        }

        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private Player player;
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        private Int32 mvCount;
        public Int32 MvCount
        {
            get { return mvCount; }
            set { mvCount = value; }
        }

        private Case currentCase;
        public Case CurrentCase
        {
            get { return currentCase; }
            set { currentCase = value; }
        }


        public Piece()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pX">column value</param>
        /// <param name="pY">row value</param>
        public Piece(Int32 pX, Int32 pY)
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
        /// <param name="pState">Piece state</param>
        /// <param name="pMvCount">Piece movement count</param>
        /// <param name="pCase">Piece case</param>
        public Piece(Int32 pX, Int32 pY, String pName, State pState, Int32 pMvCount, Case pCase)
        {
            this.XPosition = pX;
            this.YPosition = pY;
            this.CurrentCase = pCase;
            this.Name = pName;
            this.State = State.ALIVE;
            this.MvCount = 0;
        }

        /// <summary>
        /// CaseAllowed : tells if the case given in parameter is possible for move or not
        /// </summary>
        /// <param name="pCase">Case to test</param>
        /// <returns></returns>
        public bool CaseAllowed(Case pCase)
        {
            if (pCase.Piece == null || pCase.Piece.Player != Player)
            {
                return true;
            }
            return false;
        }

        public abstract Boolean MoveOK(Case pCase);
    }
}
