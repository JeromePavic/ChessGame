using ChessGame.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.database.entitiesLinks
{
    public class MySQLGameManager : MySQLManager<Game>
    {

        public void GetPlayers(Game game)
        {
            bool isDetached = this.Entry(game).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(game);
            this.Entry(game).Reference(x => x.Player1).Load();
            this.Entry(game).Reference(x => x.Player2).Load();
        }

        public void GetChessBoard(Game game)
        {
            bool isDetached = this.Entry(game).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(game);
            this.Entry(game).Reference(x => x.ChessBoard).Load();
        }

        public void GetMap(Game game)
        {
            bool isDetached = this.Entry(game).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(game);
            this.Entry(game).Reference(x => x.Map).Load();
        }

    }
}
