using ChessGame.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.database.entitiesLinks
{
    class MySQLPieceManager : MySQLManager<Piece>
    {

        public void GetCase(Piece piece)
        {
            bool isDetached = this.Entry(piece).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(piece);
            this.Entry(piece).Reference(x => x.CurrentCase).Load();
        }
    }
}
