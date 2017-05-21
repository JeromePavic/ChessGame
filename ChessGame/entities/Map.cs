using ChessGame.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    public class Map :BaseDBEntity
    {
        private String fileName;
        public String FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }


    }
}
