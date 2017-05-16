using ChessGame.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class ChessBoard : BaseDBEntity
    {
        private List<Case> cases;

        public List<Case> Cases
        {
            get { return cases; }
            set { cases = value; }
        }


        //tells if pieces are on the cases between case of origin and case to reach.
        public bool FreePath(Case pCaseNew, Case pCase)
        {
            if (pCaseNew.XPosition == pCase.XPosition && pCaseNew.YPosition > pCase.YPosition)
            {
                for (int i = pCase.YPosition; i < pCaseNew.YPosition; i++)
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
                for (int i = pCase.YPosition; i > pCaseNew.YPosition; i--)
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
                for (int i = pCase.XPosition; i < pCaseNew.XPosition; i++)
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
                for (int i = pCase.YPosition; i > pCaseNew.YPosition; i--)
                {
                    if (GetCase(i, pCase.YPosition).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.XPosition / pCase.XPosition == pCaseNew.YPosition / pCase.YPosition &&
                        pCaseNew.XPosition > pCase.XPosition && pCaseNew.YPosition > pCase.YPosition)
            {
                for (int i = pCase.XPosition, j = pCase.YPosition; i < pCaseNew.XPosition && j < pCaseNew.YPosition; i++, j++)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.XPosition / pCase.XPosition == pCaseNew.YPosition / pCase.YPosition &&
                        pCaseNew.XPosition > pCase.XPosition && pCaseNew.YPosition < pCase.YPosition)
            {
                for (int i = pCase.XPosition, j = pCase.YPosition; i < pCaseNew.XPosition && j > pCaseNew.YPosition; i++, j--)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.XPosition / pCase.XPosition == pCaseNew.YPosition / pCase.YPosition &&
                        pCaseNew.XPosition < pCase.XPosition && pCaseNew.YPosition > pCase.YPosition)
            {
                for (int i = pCase.XPosition, j = pCase.YPosition; i > pCaseNew.XPosition && j < pCaseNew.YPosition; i--, j++)
                {
                    if (GetCase(i, j).Piece != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (pCaseNew.XPosition / pCase.XPosition == pCaseNew.YPosition / pCase.YPosition &&
                        pCaseNew.XPosition < pCase.XPosition && pCaseNew.YPosition < pCase.YPosition)
            {
                for (int i = pCase.XPosition, j = pCase.YPosition; i > pCaseNew.XPosition && j > pCaseNew.YPosition; i--, j--)
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

    }

    


}
