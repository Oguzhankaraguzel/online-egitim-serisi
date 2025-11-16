namespace swissknife.Services.GraphAppServices
{
    /// <summary>
    /// Bir grafikteki noktayı temsil eder. 
    /// X ve Y koordinat değerlerini içerir.
    /// </summary>
    public struct GraphPoint
    {
        public double _x;
        public double _y;

        public GraphPoint(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Noktanın X ve Y değerlerini string formatında döndürür.
        /// </summary>
        public string ToCoordinateString()
        {
            return $"X: {_x}, Y: {_y}";
        }
    }
}
