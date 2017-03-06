using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Game
    {
        private Player player;
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        private Mode mode;
        public Mode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        private Style style;
        public Style Style
        {
            get { return style; }
            set { style = value; }
        }



    }
}
