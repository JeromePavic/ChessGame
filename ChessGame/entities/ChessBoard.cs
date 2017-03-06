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

    }
}
