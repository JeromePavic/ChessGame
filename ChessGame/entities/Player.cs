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






    }
}
