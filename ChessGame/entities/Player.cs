using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Player : BaseDBEntity
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private Rook rookLeft;
        public Rook RookLeft
        {
            get { return rookLeft; }
            set { rookLeft = value; }
        }

        private Rook rookRight;
        public Rook RookRight
        {
            get { return rookRight; }
            set { rookRight = value; }
        }

        private Knight knightLeft;
        public Knight KnightLeft
        {
            get { return knightLeft; }
            set { knightLeft = value; }
        }

        private Knight knightRight;
        public Knight KnightRight
        {
            get { return knightRight; }
            set { knightRight = value; }
        }

        private Bishop bishopLeft;
        public Bishop BishopLeft
        {
            get { return bishopLeft; }
            set { bishopLeft = value; }
        }

        private Bishop bishopRight;
        public Bishop BishopRight
        {
            get { return bishopRight; }
            set { bishopRight = value; }
        }

        private Queen queen;
        public Queen Queen
        {
            get { return queen; }
            set { queen = value; }
        }

        private King king;
        public King King
        {
            get { return king; }
            set { king = value; }
        }

        private Pawn pawn1;
        public Pawn Pawn1
        {
            get { return pawn1; }
            set { pawn1 = value; }
        }

        private Pawn pawn2;
        public Pawn Pawn2
        {
            get { return pawn2; }
            set { pawn2 = value; }
        }

        private Pawn pawn3;
        public Pawn Pawn3
        {
            get { return pawn3; }
            set { pawn3 = value; }
        }

        private Pawn pawn4;
        public Pawn Pawn4
        {
            get { return pawn4; }
            set { pawn4 = value; }
        }

        private Pawn pawn5;
        public Pawn Pawn5
        {
            get { return pawn5; }
            set { pawn5 = value; }
        }

        private Pawn pawn6;
        public Pawn Pawn6
        {
            get { return pawn6; }
            set { pawn6 = value; }
        }

        private Pawn pawn7;
        public Pawn Pawn7
        {
            get { return pawn7; }
            set { pawn7 = value; }
        }

        private Pawn pawn8;
        public Pawn Pawn8
        {
            get { return pawn8; }
            set { pawn8 = value; }
        }





    }
}
