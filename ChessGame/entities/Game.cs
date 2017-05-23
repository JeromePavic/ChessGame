using ChessGame.entities.bases;
using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Game : BaseDBEntity
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }


        private Player player1;
        public Player Player1
        {
            get { return player1; }
            set { player1 = value; }
        }

        private Player player2;
        public Player Player2
        {
            get { return player2; }
            set { player2 = value; }
        }

        private Mode mode;
        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private ChessBoard chessboard;
        public ChessBoard ChessBoard
        {
            get { return chessboard; }
            set { chessboard = value; }
        }


        public Game(String pName, Mode pMode = Mode.CLASSICAL)
        {
            this.Name = pName;
            this.Mode = pMode;
            this.Player1 = new Player();
            this.Player2 = new Player();
            this.ChessBoard = new ChessBoard(pMode);
        }


    }
}
