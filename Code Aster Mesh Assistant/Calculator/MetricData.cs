namespace Code_Aster_Mesh_Assistant.Calculator
{
    public class MetricData
    {
        #region Fields
        string _elementName;
        int _totalElementCount;
        (double Min, double Max, double Avg, double Sum) _area;
        (double Min, double Max, double Avg) _eq;
        (double Min, double Max, double Avg) _aq;
        #endregion

        #region Properties
        public string ElementName { get => _elementName; set => _elementName = value; }
        public int TotalElementCount { get => _totalElementCount; set => _totalElementCount = value; }
        public (double Min, double Max, double Avg, double Sum) Area { get => _area; set => _area = value; }
        public (double Min, double Max, double Avg) Eq { get => _eq; set => _eq = value; }
        public (double Min, double Max, double Avg) Aq { get => _aq; set => _aq = value; }
        #endregion
    }
}