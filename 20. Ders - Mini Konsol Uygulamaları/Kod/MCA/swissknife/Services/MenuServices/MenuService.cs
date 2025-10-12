using System;

namespace swissknife.Services.MenuServices
{
    public struct MenuService
    {
        public string _title;
        public string[] _options;
        public int _index;

        public MenuService(string title, string[] options)
        {
            _title = title;
            _options = options;
            _index = 0;
        }

        /// <summary>
        /// Verilen Menü başlığı ve seçenekleri ile etkileşimli bir menü görüntüler.
        /// Seçilen seçeneğin indeksini döner. ESC tuşuna basılırsa -1 döner.
        /// </summary>
        /// <returns></returns>
        public int DisplayMenu()
        {
            
            Console.CursorVisible = false;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Yön Tuşları İle Menüyü Kontol edebilirsiniz. Seçim İçin Enter, Çıkış İçin ESC \n");
                Console.WriteLine(_title);
                Console.WriteLine(new string('-', _title.Length));
                RenderOptions();
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                {
                    _index--;
                    if (_index < 0) _index = _options.Length - 1;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _index++;
                    if (_index >= _options.Length) _index = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = true;
                    return _index;
                }
                else if (key == ConsoleKey.Escape)
                {
                    Console.CursorVisible = true;
                    return -1;
                }
            }
        }

        /// <summary>
        /// Verilen seçenekleri konsola yazdırır ve seçili olan seçeneği vurgular.
        /// </summary>
        public void RenderOptions()
        {
            for (int i = 0; i < _options.Length; i++)
                if (i == _index) Console.WriteLine($"> {_options[i]}");
                else Console.WriteLine($"  { _options[i]}");
        }
    }
}
