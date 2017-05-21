using ChessGame.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.database.entitiesLinks
{
    class MySQLChessBoardManager : MySQLManager<ChessBoard>
    {
        public void GetCases(ChessBoard chessBoard)
        {
            bool isDetached = this.Entry(chessBoard).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(chessBoard);
            this.Entry(chessBoard).Collection(x => x.Cases).Load();
        }

        public void GetPieces(ChessBoard chessBoard)
        {
            bool isDetached = this.Entry(chessBoard).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(chessBoard);
            this.Entry(chessBoard).Collection(x => x.Pieces).Load();
        }

        public void GetMap(ChessBoard chessBoard)
        {
            bool isDetached = this.Entry(chessBoard).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(chessBoard);
            this.Entry(chessBoard).Reference(x => x.Map).Load();
        }
    }
}
