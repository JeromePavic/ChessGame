using ChessGame.entities.bases;
using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Player : BaseDBEntity
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Theme theme;
        public Theme Theme
        {
            get { return theme; }
            set { theme = value; }
        }

        private State state;
        public State State
        {
            get { return state; }
            set { state = value; }
        }

        private bool help;
        public bool Help
        {
            get { return help; }
            set { help = value; }
        }

        private bool white;
        public bool White
        {
            get { return white; }
            set { white = value; }
        }

        private Int32 timerSec;
        public Int32 TimerSec
        {
            get { return timerSec; }
            set { timerSec = value; }
        }

        public Player()
        {
        }

        public Player(String pName, Theme pTheme, State pState, bool pHelp, bool pWhite, Int32 pTimerSec)
        {
            this.Name = pName;
            this.Theme = pTheme;
            this.State = pState;
            this.Help = pHelp;
            this.White = pWhite;
            this.TimerSec = pTimerSec;
        }









    }
}
