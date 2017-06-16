using ChessGame.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    /// <summary>
    /// Map : class used to handle "chessboard background"
    /// </summary>
    public class Map :BaseDBEntity
    {

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String fileName;
        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


    }
}
