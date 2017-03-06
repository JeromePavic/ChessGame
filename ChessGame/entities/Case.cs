using ChessGame.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Case : Element
    {
        private Availability available;
        public Availability Available
        {
            get { return available; }
            set { available = value; }
        }

    }
}
