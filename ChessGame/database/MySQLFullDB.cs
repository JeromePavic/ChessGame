using ClassLibrary2.Entities.Generator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGame.entities;
using ChessGame.json;

namespace ChessGame.database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        public DbSet<Bishop> BishopTable { get; set; }
        public DbSet<Case> CaseTable { get; set; }
        public DbSet<King> KingTable { get; set; }
        public DbSet<Knight> KnightTable { get; set; }
        public DbSet<Pawn> PawnTable { get; set; }
        public DbSet<Queen> QueenTable { get; set; }
        public DbSet<Rook> RookTable { get; set; }
        public DbSet<Player> PlayerTable { get; set; }
        public DbSet<Game> GameTable { get; set; }



        public MySQLFullDB()
            : base(JsonManager.Instance.ReadFile<ConnectionString>(@"..\..\..\jsonconfig\", @"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        public void InitLocalMySQL()
        {
            this.Database.CreateIfNotExists();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
