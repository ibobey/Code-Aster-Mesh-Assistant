using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Aster_Mesh_Assistant.Entity
{
    public static class KeyWords
    {
        public const string TITRE = "TITRE";
        public const string FINSF = "FINSF";
        public const string COOR_3D = "COOR_3D";
        public const string QUAD4 = "QUAD4";
        public const string TRIA3 = "TRIA3";
        public const string GROUP_MA_NOM = "GROUP_MA NOM=";
        public const string FIN = "FIN";
        public const string FEM_ANALYZER = "FemAnalyzer";
        public const string SEG2 = "SEG2";
        public const string TOTAL = "TOTAL";

        public static readonly HashSet<string> Keywords = new() { TITRE, COOR_3D, QUAD4, TRIA3, SEG2 };
    }
}
