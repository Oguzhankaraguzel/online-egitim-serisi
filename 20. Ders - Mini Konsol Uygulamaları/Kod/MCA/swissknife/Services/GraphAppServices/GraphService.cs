using System;
using System.Collections.Generic;

namespace swissknife.Services.GraphAppServices
{
    public struct GraphService
    {
        public string DrawGraph(List<GraphPoint> points, int maxWH)
        {
            //25 
            char[,] canvas = PrepareCanvas(maxWH + 1);

            canvas = DrawPointOnCanvas(points, canvas, maxWH + 1);

            canvas = DrawDotBetweenPoints(points, canvas, maxWH + 1);

            string result = string.Empty;
            for (int i = 0; i < maxWH + 1; i++)
            {
                for (int j = 0; j < maxWH + 1; j++)
                {
                    result += (canvas[i, j]);
                }
                result += "\n";
            }

            return result;
        }

        public char[,] DrawDotBetweenPoints(List<GraphPoint> points, char[,] canvas, int maxWH)
        {
            if (points.Count < 2)
                return canvas;

            int center = maxWH / 2;
            // todo: implement Bresenham's line algorithm for better line drawing
            // todo: noktaların orjin uzaklığına göre sıralı yeni bir liste oluşturup oraya çizgi çekmek daha doğru olabilir.
            for (int i = 0; i < points.Count - 1; i++)
            {
                GraphPoint p1 = points[i];
                GraphPoint p2 = points[i + 1];

                int x0 = center + (int)Math.Round(p1._x);
                int y0 = center - (int)Math.Round(p1._y);
                int x1 = center + (int)Math.Round(p2._x);
                int y1 = center - (int)Math.Round(p2._y);

                int dx = Math.Abs(x1 - x0);
                int dy = Math.Abs(y1 - y0);

                int step = Math.Max(dx, dy);

                double xIncrement = (x1 - x0) / (double)step;
                double yIncrement = (y1 - y0) / (double)step;

                double x = x0;
                double y = y0;

                for (int j = 0; j < step; j++)
                {
                    int xi = (int)Math.Round(x);
                    int yi = (int)Math.Round(y);

                    if (xi >= 0 && xi < maxWH && yi >= 0 && yi < maxWH)
                    {
                        if (canvas[yi, xi] == '*') { }

                        else if (canvas[yi, xi] == '|' || canvas[yi, xi] == '-')
                            canvas[yi, xi] = '+';

                        else
                            canvas[yi, xi] = '.';
                    }

                    x += xIncrement;
                    y += yIncrement;
                }
            }
            return canvas;
        }

        public char[,] DrawPointOnCanvas(List<GraphPoint> points, char[,] canvas, int maxWH)
        {
            int center = maxWH / 2;

            foreach (GraphPoint point in points)
            {
                int canvasX = center + (int)Math.Round(point._x);
                int canvasY = center - (int)Math.Round(point._y);

                if (canvas[canvasY, canvasX] == '|' || canvas[canvasY, canvasX] == '-')
                    canvas[canvasY, canvasX] = '+';

                else
                    canvas[canvasY, canvasX] = '*';

            }
            return canvas;
        }
        public char[,] PrepareCanvas(int maxWH)
        {
            char[,] canvas = new char[maxWH, maxWH];
            for (int i = 0; i < maxWH; i++)
                for (int j = 0; j < maxWH; j++)
                    canvas[i, j] = ' ';

            for (int i = 0; i < maxWH; i++)
            {
                canvas[i, maxWH / 2] = '|';
                canvas[maxWH / 2, i] = '-';
            }

            canvas[maxWH / 2, maxWH / 2] = '+';
            return canvas;
        }
        public List<GraphPoint> ScalePoints(List<GraphPoint> points, int maxWH, out double scale)
        {
            List<GraphPoint> scaledPoints = new List<GraphPoint>();

            double maxCoordinate = 0;

            foreach (GraphPoint point in points)
            {
                if (maxCoordinate < Math.Abs(point._x))
                    maxCoordinate = Math.Abs(point._x);

                if (maxCoordinate < Math.Abs(point._y))
                    maxCoordinate = Math.Abs(point._y);
            }

            if (maxCoordinate == 0)
            {
                scale = 1;
                return points;
            }

            scale = maxWH / (2 * maxCoordinate);

            foreach (GraphPoint point in points)
            {
                GraphPoint scaledPoint = new GraphPoint
                {
                    _x = point._x * scale,
                    _y = point._y * scale
                };
                scaledPoints.Add(scaledPoint);
            }

            return scaledPoints;
        }
    }
}
