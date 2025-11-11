using swissknife.Services.Extensions;
using swissknife.Services.GraphAppServices;
using swissknife.Services.MenuServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace swissknife.Applications
{
    public struct GraphApp
    {
        public List<GraphPoint> _points;
        public List<GraphPoint> _scaledPoints;
        public double _scale;
        public const int _canvasSize = 26;

        public const string _title = "Grafik Uygulaması";
        public static string[] options = new string[]
        {
            "Nokta Ekle",
            "Noktaları Görüntüle",
            "Grafik Çizdir",
        };

        public void Run()
        {
            SafeStart(false);
            MenuService menuService = new MenuService(_title, options);
            GraphService graphService = new GraphService();

            bool running = true;
            while (running)
            {
                int choice = menuService.DisplayMenu();
                switch (choice)
                {
                    case 0:
                        AddPoint();
                        break;
                    case 1:
                        ViewPoints();
                        break;
                    case 2:
                        Render(graphService);
                        break;
                    case -1:
                        running = !ConsoleEx.ConfirmExit();
                        break;
                    default:
                        break;
                }
            }

        }

        public void Render(GraphService service)
        {
            SafeStart(false);

            _scaledPoints = service.ScalePoints(_points, _canvasSize, out _scale);
            string graph = service.DrawGraph(_scaledPoints, _canvasSize);

            string output = string.Empty;
            output += "Ölçek: ";
            output += _scale.ToString();
            output += "\nNoktalar:";

            foreach (GraphPoint point in _points)
                output += "\n" + point.ToCoordinateString();
            
            output += "\n" + graph;

            Console.WriteLine(output);

            ConsoleEx.Pause();
        }

        public void ViewPoints()
        {
            //Todo: Noktalar için ekleme silme güncelleme fonksiyonları ekle. Ödev!
            SafeStart(false);

            if (_points.Count == 0)
            {
                Console.WriteLine("Henüz eklenmiş nokta yok.");
                ConsoleEx.Pause();
            }
            else
            {
                Console.WriteLine("Eklenmiş Noktalar:");
                foreach (GraphPoint point in _points)
                {
                    Console.WriteLine(point.ToCoordinateString());
                }
                ConsoleEx.Pause();
            }
        }

        public void AddPoint()
        {
            /*
             * Bazı kültürlerde ondalık ayırıcı olarak nokta (.) yerine virgül (,) kullanılır.
             * Bazılarında nokta kullanılır.
             * Ancak C#'ta ondalık sayıları işlerken kültüre bağlı olarak farklılık gösterebilir.
             */
            SafeStart(true);

            Console.Write("X: ");
            string x = Console.ReadLine();
            bool validInput = double.TryParse(x, out double xCoord);

            while (!validInput)
            {
                Console.Clear();
                Console.WriteLine("Geçersiz giriş. Lütfen geçerli bir sayı girin: ");
                Console.Write("X: ");
                x = Console.ReadLine();
                validInput = double.TryParse(x, out xCoord);
            }
            Console.Clear();
            Console.Write($"X: {x}\nY: ");
            string y = Console.ReadLine();
            validInput = double.TryParse(y, out double yCoord);
            while (!validInput)
            {
                Console.Clear();
                Console.WriteLine("Geçersiz giriş. Lütfen geçerli bir sayı girin: ");
                Console.Write($"X: {x}\nY: ");
                y = Console.ReadLine();
                validInput = double.TryParse(y, out yCoord);
            }

            GraphPoint newPoint = new GraphPoint(xCoord, yCoord);
            _points.Add(newPoint);
        }

        public void SafeStart(bool cursorVisible) 
        {
            Console.Clear();
            Console.CursorVisible = cursorVisible;

            if (_points == null)
                _points = new List<GraphPoint>();
        }
    }
}
