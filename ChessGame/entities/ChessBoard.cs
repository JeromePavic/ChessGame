using ChessGame.entities.bases;
using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class ChessBoard : BaseDBEntity
    {
        private const Int32 ChessBoardSize = 8;
        private Mode mode;

        //===============================================================================================================
        // PROPERTIES
        //===============================================================================================================

        private List<Case> cases;
        public List<Case> Cases
        {
            get { return cases; }
            set { cases = value; }
        }

        private List<Piece> pieces;
        public List<Piece> Pieces
        {
            get { return pieces; }
            set { pieces = value; }
        }


        private Case caseOfKIC;
        public Case CaseOfKIC
        {
            get { return caseOfKIC; }
            set { caseOfKIC = value; }
        }

        private bool kingInCheck;
        public bool KingInCheck
        {
            get { return kingInCheck; }
            set { kingInCheck = value; }
        }

        private Case p1KingCase;
        public Case P1KingCase
        {
            get { return p1KingCase; }
            set { p1KingCase = value; }
        }

        private Case p2KingCase;
        public Case P2KingCase
        {
            get { return p2KingCase; }
            set { p2KingCase = value; }
        }



        //private Map map;
        //public Map Map
        //{
        //    get { return map; }
        //    set { map = value; }
        //}


        //===============================================================================================================
        // CONSTRUCTORS
        //===============================================================================================================

        public ChessBoard()
        {
            this.mode = Mode.CLASSICAL;
            this.pieces = new List<Piece>();
            this.cases = new List<Case>();
            InitCases();
            InitPieces();
        }

        public ChessBoard(Mode pMode)
        {
            this.mode = pMode;
            this.pieces = new List<Piece>();
            this.cases = new List<Case>();
            InitCases();
            InitPieces();
            PiecesToCases();
        }

        


        //===============================================================================================================
        // METHODS
        //===============================================================================================================

        //initializes the list of cases
        private void InitCases()
        {
            for (int i = 0; i < ChessBoardSize; i++)
            {
                for (int j = 0; j < ChessBoardSize; j++)
                {
                    cases.Add(new Case(i,j));
                }
            }
            if (this.mode == Mode.MAD)
            {
                ShuffleCases(cases);
            }
        }

        private void InitPieces()
        {
            if (this.mode != Mode.WAR) // global case : classical pieces init
            {
                pieces.Add(new Rook(0, 0, "p1Rook1", this.GetCase(0, 0)));
                pieces.Add(new Knight(1, 0, "p1Knight1", this.GetCase(1,0)));
                pieces.Add(new Bishop(2, 0, "p1Bishop1", this.GetCase(2, 0)));
                pieces.Add(new Queen(3, 0, "p1Queen", this.GetCase(3, 0)));
                pieces.Add(new King(4, 0, "p1King", this.GetCase(4, 0)));
                pieces.Add(new Bishop(5, 0, "p1Bishop2", this.GetCase(5, 0)));
                pieces.Add(new Knight(6, 0, "p1Knight2", this.GetCase(6,0)));
                pieces.Add(new Rook(7, 0, "p1Rook2", this.GetCase(7,0)));
                pieces.Add(new Pawn(0, 1, "p1Pawn1", this.GetCase(0,1)));
                pieces.Add(new Pawn(1, 1, "p1Pawn2", this.GetCase(1,1)));
                pieces.Add(new Pawn(2, 1, "p1Pawn3", this.GetCase(2,1)));
                pieces.Add(new Pawn(3, 1, "p1Pawn4", this.GetCase(3,1)));
                pieces.Add(new Pawn(4, 1, "p1Pawn5", this.GetCase(4,1)));
                pieces.Add(new Pawn(5, 1, "p1Pawn6", this.GetCase(5,1)));
                pieces.Add(new Pawn(6, 1, "p1Pawn7", this.GetCase(6,1)));
                pieces.Add(new Pawn(7, 1, "p1Pawn8", this.GetCase(7,1)));

                pieces.Add(new Pawn(0, 6, "p2Pawn1", this.GetCase(0,6)));
                pieces.Add(new Pawn(1, 6, "p2Pawn2", this.GetCase(1,6)));
                pieces.Add(new Pawn(2, 6, "p2Pawn3", this.GetCase(2,6)));
                pieces.Add(new Pawn(3, 6, "p2Pawn4", this.GetCase(3,6)));
                pieces.Add(new Pawn(4, 6, "p2Pawn5", this.GetCase(4,6)));
                pieces.Add(new Pawn(5, 6, "p2Pawn6", this.GetCase(5,6)));
                pieces.Add(new Pawn(6, 6, "p2Pawn7", this.GetCase(6,6)));
                pieces.Add(new Pawn(7, 6, "p2Pawn8", this.GetCase(7,6)));
                pieces.Add(new Rook(0, 7, "p2Rook1", this.GetCase(0,7)));
                pieces.Add(new Knight(1, 7, "p2Knight1", this.GetCase(1, 7)));
                pieces.Add(new Bishop(2, 7, "p2Bishop1", this.GetCase(2, 7)));
                pieces.Add(new Queen(3, 7, "p2Queen", this.GetCase(3, 7)));
                pieces.Add(new King(4, 7, "p2King", this.GetCase(4, 7)));
                pieces.Add(new Bishop(5, 7, "p2Bishop2", this.GetCase(5, 7)));
                pieces.Add(new Knight(6, 7, "p2Knight2", this.GetCase(6, 7)));
                pieces.Add(new Rook(7, 7, "p2Rook2", this.GetCase(7, 7)));
            }
            else // WAR mode : special pieces init
            {
                pieces.Add(new Rook(0, 0, "p1Rook1", this.GetCase(0, 0)));
                pieces.Add(new Rook(1, 0, "p1Rook2", this.GetCase(1, 0)));
                pieces.Add(new Bishop(2, 0, "p1Bishop1", this.GetCase(2, 0)));
                pieces.Add(new Queen(3, 0, "p1Queen1", this.GetCase(3, 0)));
                pieces.Add(new King(4, 0, "p1King", this.GetCase(4, 0)));
                pieces.Add(new Queen(5, 0, "p1Queen2", this.GetCase(5, 0)));
                pieces.Add(new Bishop(6, 0, "p1Bishop2", this.GetCase(6, 0)));
                pieces.Add(new Rook(7, 0, "p1Rook3", this.GetCase(7, 0)));
                pieces.Add(new Knight(0, 1, "p1Knight1", this.GetCase(0,1)));
                pieces.Add(new Knight(1, 1, "p1Knight2", this.GetCase(1,1)));
                pieces.Add(new Knight(2, 1, "p1Knight3", this.GetCase(2,1)));
                pieces.Add(new Bishop(3, 1, "p1Bishop3", this.GetCase(3,1)));
                pieces.Add(new Bishop(4, 1, "p1Bishop4", this.GetCase(4,1)));
                pieces.Add(new Knight(5, 1, "p1Knight4", this.GetCase(5,1)));
                pieces.Add(new Knight(6, 1, "p1Knight5", this.GetCase(6,1)));
                pieces.Add(new Knight(7, 1, "p1Knight6", this.GetCase(7,1)));

                pieces.Add(new Knight(0, 6, "p2Knight1", this.GetCase(0,6)));
                pieces.Add(new Knight(1, 6, "p2Knight2", this.GetCase(1,6)));
                pieces.Add(new Knight(2, 6, "p2Knight3", this.GetCase(2,6)));
                pieces.Add(new Bishop(3, 6, "p2Bishop1", this.GetCase(3,6)));
                pieces.Add(new Bishop(4, 6, "p2Bishop2", this.GetCase(4,6)));
                pieces.Add(new Knight(5, 6, "p2Knight4", this.GetCase(5,6)));
                pieces.Add(new Knight(6, 6, "p2Knight5", this.GetCase(6,6)));
                pieces.Add(new Knight(7, 6, "p2Knight6", this.GetCase(7,6)));
                pieces.Add(new Rook(0, 7, "p2Rook1", this.GetCase(0, 7)));
                pieces.Add(new Rook(1, 7, "p2Rook2", this.GetCase(1, 7)));
                pieces.Add(new Bishop(2, 7, "p2Bishop3", this.GetCase(2, 7)));
                pieces.Add(new Queen(3, 7, "p2Queen1", this.GetCase(3, 7)));
                pieces.Add(new King(4, 7, "p2King", this.GetCase(4, 7)));
                pieces.Add(new Queen(5, 7, "p2Queen2", this.GetCase(5, 7)));
                pieces.Add(new Bishop(6, 7, "p2Bishop4", this.GetCase(6, 7)));
                pieces.Add(new Rook(7, 7, "p2Rook3", this.GetCase(7, 7)));
            }

            p1KingCase = GetCase(4, 0);
            p2KingCase = GetCase(4, 7);
        }


        // set a piece to cases
        private void PiecesToCases()
        {
            for (int i = 0; i < Cases.Count; i++)
            {
                Int32 x = Cases[i].XPosition;
                Int32 y = Cases[i].YPosition;

                Cases[i].Piece = GetPiece(x, y);
            }
        }


        //tells if pieces are on the cases between case of origin and case to reach.
        public bool FreePath(Case pCaseNew, Case pCase)
        {
            // Knight is not concerned by this rule...
            if (pCase.Piece.GetType().Equals(typeof(Knight)))
            {
                return true;
            }

            if (pCaseNew.XPosition == pCase.XPosition && pCaseNew.YPosition > pCase.YPosition)
            {
                for (int i = pCase.YPosition + 1; i < pCaseNew.YPosition; i++)
                {
                    if (GetCase(pCase.XPosition, i).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.XPosition == pCase.XPosition && pCaseNew.YPosition < pCase.YPosition)
            {
                for (int i = pCase.YPosition - 1; i > pCaseNew.YPosition; i--)
                {
                    if (GetCase(pCase.XPosition, i).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.YPosition == pCase.YPosition && pCaseNew.XPosition > pCase.XPosition)
            {
                for (int i = pCase.XPosition + 1; i < pCaseNew.XPosition; i++)
                {
                    if (GetCase(i, pCase.YPosition).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.YPosition == pCase.YPosition && pCaseNew.XPosition < pCase.XPosition)
            {
                for (int i = pCase.YPosition - 1; i > pCaseNew.YPosition; i--)
                {
                    if (GetCase(i, pCase.YPosition).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if ((Math.Abs(pCaseNew.XPosition - pCase.XPosition) == Math.Abs(pCaseNew.YPosition - pCase.YPosition)) &&
                        pCaseNew.XPosition > pCase.XPosition && pCaseNew.YPosition > pCase.YPosition)
            {
                for (int i = pCase.XPosition + 1, j = pCase.YPosition + 1; i < pCaseNew.XPosition && j < pCaseNew.YPosition; i++, j++)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if ((Math.Abs(pCaseNew.XPosition - pCase.XPosition) == Math.Abs(pCaseNew.YPosition - pCase.YPosition)) &&
                        pCaseNew.XPosition > pCase.XPosition && pCaseNew.YPosition < pCase.YPosition)
            {
                for (int i = pCase.XPosition + 1, j = pCase.YPosition - 1; i < pCaseNew.XPosition && j > pCaseNew.YPosition; i++, j--)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if ((Math.Abs(pCaseNew.XPosition - pCase.XPosition) == Math.Abs(pCaseNew.YPosition - pCase.YPosition)) &&
                        pCaseNew.XPosition < pCase.XPosition && pCaseNew.YPosition > pCase.YPosition)
            {
                for (int i = pCase.XPosition - 1, j = pCase.YPosition + 1; i > pCaseNew.XPosition && j < pCaseNew.YPosition; i--, j++)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if ((Math.Abs(pCaseNew.XPosition - pCase.XPosition) == Math.Abs(pCaseNew.YPosition - pCase.YPosition)) &&
                        pCaseNew.XPosition < pCase.XPosition && pCaseNew.YPosition < pCase.YPosition)
            {
                for (int i = pCase.XPosition - 1, j = pCase.YPosition - 1; i > pCaseNew.XPosition && j > pCaseNew.YPosition; i--, j--)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        //returns the case at the position or null
        public Case GetCase(Int32 pX, Int32 pY)
        {
            foreach (var caseItem in cases)
            {
                if (caseItem.XPosition == pX && caseItem.YPosition == pY)
                {
                    return caseItem;
                } 
            }
            return null;
        }

        //returns the piece at the position or null
        public Piece GetPiece(Int32 pX, Int32 pY)
        {
            foreach (var pieceItem in pieces)
            {
                if (pieceItem.XPosition == pX && pieceItem.YPosition == pY)
                {
                    return pieceItem;
                }
            }
            return null;
        }

        public bool MovePossible(Piece pPiece, Case pCase)
        {
            if (pPiece.MoveOK(pCase) && FreePath(pCase, pPiece.CurrentCase) && OnBoard(pCase))
            {
                return true;
            }
            return false;
        }


        private bool OnBoard(Case pCase)
        {
            if (pCase.XPosition >= 0 && pCase.XPosition <= 7 && pCase.YPosition >= 0 && pCase.YPosition <= 7)
            {
                return true;
            }
            return false;
        }

        //effective movement
        private void MoveTo(Piece pPiece, Case pCase)
        {   
            Case oldCase = pPiece.CurrentCase;
            oldCase.Piece = null;
            pCase.Piece = pPiece;
            pPiece.CurrentCase = pCase;
            pPiece.XPosition = pCase.XPosition;
            pPiece.YPosition = pCase.YPosition;
            pPiece.MvCount++;
        }

        //handle move of a piece to a new case
        public bool Move(Piece pPiece, Case pCase)
        {
            if (MovePossible(pPiece, pCase))
            {
                MoveTo(pPiece, pCase);
                return true;
            }
            return false;
        }


        public bool Kill(Piece pPiece)
        {
            if (Pieces.Remove(pPiece))
            {
                return true;
            }
            return false;
        }


        public bool PutKingInCheck(Case pCaseOfKing, Player pPlayer)
        {
            foreach (Piece piece in pieces)
            {
                if (piece.Player != pPlayer && MovePossible(piece, pCaseOfKing))
                {
                    kingInCheck = true;
                    return true;
                }
            }
            return false;
        }


        private static void ShuffleCases(List<Case> pCases)
        {
            Random rng = new Random();
            if (pCases == null)
                throw new ArgumentNullException("pCases");

            for (int i = pCases.Count; i > 1; --i)
            {
                // Pick random element to swap.
                int j = rng.Next(i); // 0 <= j <= i-1
                                     // Swap.
                Case tmp = pCases[j];
                pCases[j] = pCases[i - 1];
                pCases[i - 1] = tmp;
            }
        }

    }
}
