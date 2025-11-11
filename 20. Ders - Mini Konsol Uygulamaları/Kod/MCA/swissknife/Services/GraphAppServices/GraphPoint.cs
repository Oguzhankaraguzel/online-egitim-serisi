namespace swissknife.Services.GraphAppServices
{
    public struct GraphPoint
    {
        public double _x;
        public double _y;

        public GraphPoint(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public string ToCoordinateString()
        {
            return $"X: {_x}, Y: {_y}";
        }
    }
}
