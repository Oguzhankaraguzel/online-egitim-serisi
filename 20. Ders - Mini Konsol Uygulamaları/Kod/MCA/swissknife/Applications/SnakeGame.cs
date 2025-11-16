using swissknife.Services.Extensions;
using swissknife.Services.GameServices.Snake;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace swissknife.Applications
{
    public struct SnakeGame
    {
        public SnakeSegments[] _snakeSegments;
        public const int _maxWidth = 40;
        public const int _maxHeight = 20;
        public const int _snakeStartLength = 4;
        public const int _frameDelay = 120; //ms
        public static Random _rnd = new Random();

        public int _snakeLength;
        public bool _running;
        public int _score;
        public int _dirX;
        public int _dirY;
        public int _foodX;
        public int _foodY;

        /// <summary>
        /// Oyunu başlatır ve uygulamayı yönetir.
        /// </summary>
        public void Run()
        {
            InitGame();
            Stopwatch sw = Stopwatch.StartNew();
            while (_running)
            {
                sw.Restart();

                HandleInput();
                Update();

                if (!_running)
                    break;
                
                Draw();

                sw.Stop();
                int delay = _frameDelay - (int)sw.ElapsedMilliseconds;
                delay = delay < 0 ? 0 : delay;
                Thread.Sleep(delay);
            }

            Console.WriteLine($"Oyun bitti! Skorunuz: {_score}");
            ConsoleEx.Pause();
        }

        public void Draw()
        {
            char[,] grid = new char[_maxHeight + 2, _maxWidth + 2];

            for (int x = 0; x < _maxWidth + 2; x++)
                for (int y = 0; y < _maxHeight + 2; y++)
                    grid[y,x] = ' ';

            //Grid çerçevesi çiziliyor
            for (int x = 0; x < _maxWidth + 2; x++)
            {
                grid[0,x] = '*';
                grid[_maxHeight + 1,x] = '*';
            }
            for (int y = 0; y < _maxHeight + 2; y++)
            {
                grid[y,0] = '*';
                grid[y,_maxWidth + 1] = '*';
            }

            //yılan çerçeveye çiziliyor.
            grid[_snakeSegments[0]._y, _snakeSegments[0]._x] = 'O';
            for (int i = 1; i < _snakeLength; i++)
            {
                grid[_snakeSegments[i]._y, _snakeSegments[i]._x] = 'o';
            }

            //yiyecek çerçeveye çiziliyor
            grid[_foodY, _foodX] = '*';

            //grid ekrana yazdırılıyor.
            StringBuilder sb = new StringBuilder();
            sb.Append($"Yılan Oyunu\nESC Çıkış, Ok Tuşları Yön\nSkor: {_score}\n");

            for (int y = 0; y < _maxHeight + 2; y++)
            {
                for (int x = 0; x < _maxWidth + 2; x++)
                {
                    sb.Append(grid[y,x]);
                }
                sb.Append(Environment.NewLine);
            }
            Console.Clear();
            Console.WriteLine(sb.ToString());
        }

        public void Update()
        {
            MoveSnake();

            SnakeSegments head = _snakeSegments[0];

            if (head._x < 1 || head._x > _maxWidth  || head._y < 1 || head._y > _maxHeight)
            {
                _running = false;
                return;
            }

            for (int i = 1; i < _snakeLength; i++)
            {
                if (_snakeSegments[i]._x == head._x && _snakeSegments[i]._y == head._y)
                {
                    _running = false;
                    return;
                }
            }

            if (head._x == _foodX && head._y == _foodY) 
            {
                Grow();
                PlaceFood();
                _score += 10;
            }
        }

        public void Grow()
        {
            if (_snakeLength < (_maxWidth * _maxHeight))
            {
                _snakeSegments[_snakeLength] = _snakeSegments[_snakeLength - 1];
                _snakeLength++;
            }
        }

        public void MoveSnake()
        {
            for (int i = _snakeLength - 1; i > 0 ; i--)
            {
                _snakeSegments[i] = _snakeSegments[i - 1];
            }

            _snakeSegments[0]._x += _dirX;
            _snakeSegments[0]._y += _dirY;
        }

        public void HandleInput()
        {
            if (!Console.KeyAvailable) return;

            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                _running = false;

            else if (key == ConsoleKey.UpArrow && _dirY != 1)
            {
                _dirX = 0;
                _dirY = -1;
            }
            else if (key == ConsoleKey.RightArrow && _dirX != -1)
            {
                _dirX = 1;
                _dirY = 0;
            }
            else if (key == ConsoleKey.DownArrow && _dirY != -1)
            {
                _dirX = 0;
                _dirY = 1;
            }
            else if (key == ConsoleKey.LeftArrow && _dirX != 1)
            {
                _dirX = -1;
                _dirY = 0;
            }
        }

        /// <summary>
        /// Oyunu başlamaya hazır hale getirir.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void InitGame()
        {
            Console.CursorVisible = false;
            _snakeSegments = new SnakeSegments[_maxHeight * _maxWidth];
            for (int i = 0; i < _snakeStartLength; i++)
            {
                _snakeSegments[i]._x = (_maxWidth / 2) - i;
                _snakeSegments[i]._y = _maxHeight / 2;
            }

            _snakeLength = _snakeStartLength;
            _running = true;
            _score = 0;
            _dirX = 1;
            _dirY = 0;

            PlaceFood();
        }

        /// <summary>
        /// Yiyeceğin x ve y noktasını belirler.
        /// </summary>
        public void PlaceFood()
        {
            while (true)
            {
                int x = _rnd.Next(1, _maxWidth + 1);
                int y = _rnd.Next(1, _maxHeight + 1);
                bool conflict = false;
                for (int i = 0; i < _snakeLength; i++)
                {
                    if (_snakeSegments[i]._x == x && _snakeSegments[i]._y == y)
                    {
                        conflict = true;
                        break;
                    }
                }
                if (!conflict)
                {
                    _foodX = x;
                    _foodY = y;
                    return;
                }
            }
        }
    }
}
