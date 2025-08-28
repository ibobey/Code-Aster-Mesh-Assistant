namespace Code_Aster_Mesh_Assistant.Calculator
{
    public class MeshData
    {
        #region Fields
        int _node;
        int _seg2;
        int _tria3;
        int _quad4;
        int _total;
        #endregion

        public int Node { get => _node; set => _node = value; }
        public int Seg2 { get => _seg2; set => _seg2 = value; }
        public int Tria3 { get => _tria3; set => _tria3 = value; }
        public int Quad4 { get => _quad4; set => _quad4 = value; }
        public int Total { get => _seg2 + _tria3 + _quad4; }


    }
}