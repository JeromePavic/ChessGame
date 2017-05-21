using ChessGame.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.database.entitiesLinks
{
    public class MySQLPlayerManager : MySQLManager<Player>
    {

        public void GetTheme(Player player)
        {
            bool isDetached = this.Entry(player).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(player);
            this.Entry(player).Reference(x => x.Theme).Load();
        }
    }
}
