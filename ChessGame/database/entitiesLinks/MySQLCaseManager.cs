using ChessGame.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.database.entitiesLinks
{
    class MySQLCaseManager : MySQLManager<Case>
    {

        public void GetPiece(Case pCase)
        {
            bool isDetached = this.Entry(pCase).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(pCase);
            this.Entry(pCase).Reference(x => x.Piece).Load();
        }
    }
}
