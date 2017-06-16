using ChessGame.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame.entities
{
    /// <summary>
    /// Theme : class used to handle the images used for the pieces representation
    /// </summary>
    public class Theme : BaseDBEntity
    {

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String pawnFileName;
        public String PawnFileName
        {
            get { return pawnFileName; }
            set { pawnFileName = value; }
        }

        private String rookFileName;
        public String RookFileName
        {
            get { return rookFileName; }
            set { rookFileName = value; }
        }

        private String knightFileName;
        public String KnightFileName
        {
            get { return knightFileName; }
            set { knightFileName = value; }
        }

        private String bishopFileName;
        public String BishopFileName
        {
            get { return bishopFileName; }
            set { bishopFileName = value; }
        }

        private String queenFileName;
        public String QueenFileName
        {
            get { return queenFileName; }
            set { queenFileName = value; }
        }

        private String kingFileName;
        public String KingFileName
        {
            get { return kingFileName; }
            set { kingFileName = value; }
        }

        public Theme()
        {
        }

    }
}
