using ChessGame.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Theme : BaseDBEntity
    {

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private Dictionary<Piece,String> images;
        public Dictionary<Piece, String> Images
        {
            get { return images; }
            set { images = value; }
        }

        public Theme()
        {
            this.images = new Dictionary<Piece, String>();
        }

    }
}
