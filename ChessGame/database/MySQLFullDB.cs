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
        
        
        
        public DbSet<Map> MapTable { get; set; }
        //public DbSet<Case> CaseTable { get; set; }
        public DbSet<Theme> ThemeTable { get; set; }
        public DbSet<Player> PlayerTable { get; set; }
        public DbSet<Piece> PieceTable { get; set; }
        public DbSet<Bishop> BishopTable { get; set; }
        public DbSet<King> KingTable { get; set; }
        public DbSet<Knight> KnightTable { get; set; }
        public DbSet<Pawn> PawnTable { get; set; }
        public DbSet<Queen> QueenTable { get; set; }
        public DbSet<Rook> RookTable { get; set; }
        public DbSet<ChessBoard> ChessBoardTable { get; set; }
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
            //one-to-many 
            modelBuilder.Entity<Piece>()
                        .HasRequired<ChessBoard>(s => s.ChessBoard) // Student entity requires Standard 
                        .WithMany(s => s.Pieces); // Standard entity includes many Students entities

            //handle of zero-or-one to zero-or-one relationship between Case and Piece.
            //modelBuilder.Entity<Piece>()
            //            .HasOptional(x => x.CurrentCase)
            //            .WithOptionalDependent()
            //            .Map(x => x.MapKey("Piece_Id"));

            //modelBuilder.Entity<Case>()
            //            .HasOptional(x => x.Piece)
            //            .WithOptionalPrincipal()
            //            .Map(x => x.MapKey("Case_Id"));

        }
    }
}
