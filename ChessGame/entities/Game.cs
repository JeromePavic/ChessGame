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

        private Player currentPlayer;
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
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

        private String background;
        public String Background
        {
            get { return background; }
            set { background = value; }
        }



        public Game(String pName, Mode pMode = Mode.CLASSICAL)
        {
            this.Name = pName;
            this.Mode = pMode;
            this.Player1 = new Player("Player1", null, State.ALIVE, true, true);
            Player1.White = true;
            this.Player2 = new Player("Player2", null, State.ALIVE, true, false);
            Player2.White = false;
            this.CurrentPlayer = Player1;
            this.ChessBoard = new ChessBoard(pMode);
            // set a player for each piece of the chessboard
            int mid = ChessBoard.Pieces.Count / 2;
            for (int i = 0; i < mid; i++)
            {
                ChessBoard.Pieces[i].Player = Player1;
            }
            for (int i = mid; i < ChessBoard.Pieces.Count; i++)
            {
                ChessBoard.Pieces[i].Player = Player2;
            }

        }


    }
}
