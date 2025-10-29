using swissknife.Services.FileServices;
using swissknife.Services.GameServices.Hangman;
using swissknife.Services.MenuServices;
using swissknife.Services.UserServices;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace swissknife.Applications
{
    public struct HangmanGame
    {
        public const string _tenSpaces = "          ";
        public int _score;
        public int _bestScore;
        public string _selectedGroup;
        public string[] _words;
        public string _currentWord;
        public string _maskedWord;
        public int _wrongAttempts;
        public const int _maxWrongAttempts = 6;
        public void Run()
        {
            UserService userService = new UserService();
            UserProfile? user = userService.GetUser();
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı. Lütfen bir kullanıcı oluşturunuz!");

            Start:

            bool sessionActive = InitializeGame(user.Value);

            if (!sessionActive) return;

            while (sessionActive)
            {
                Render();
                sessionActive = HandleInput(ref user);
            }

            bool confirmExit = HandleEndSession();

            if (!confirmExit)
            {
                goto Start;
            }
            return;
        }

        public bool HandleEndSession()
        {
            Console.WriteLine($"{_tenSpaces}Çıkmak İçin ESC, Yeni Kelime Grubu Seçmek İçin Enter");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        HandleEndSession:
            if (keyInfo.Key == ConsoleKey.Escape)
                return true;
            if (keyInfo.Key == ConsoleKey.Enter)
                return false;
            goto HandleEndSession;
        }

        public bool HandleInput(ref UserProfile? user)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
                return false;

            if (!char.IsLetter(keyInfo.KeyChar))
                return true;

            char guessedChar = char.ToLower(keyInfo.KeyChar);

            //Burayı bir metod olarak dışarı alabilirsiniz.
            if (_currentWord.Contains(guessedChar) && !_maskedWord.Contains(guessedChar))
            {
                _score += 10;
                char[] tempMasked = _maskedWord.ToCharArray();

                for (int i = 0; i < _currentWord.Length; i++)
                    if (_currentWord[i] == guessedChar)
                        tempMasked[i] = guessedChar;
                    else if (tempMasked[i] != '_')
                        continue;
                    else
                        tempMasked[i] = '_';

                _maskedWord = new string(tempMasked);
            }
            else if (_currentWord.Contains(guessedChar))
            {
                // Zaten tahmin edilmiş harf
            }
            else
            {
                _wrongAttempts++;
            }

            Render();
            if (_wrongAttempts == _maxWrongAttempts)
            {
                Console.WriteLine($"{_tenSpaces}Oyunu Kaybettiniz! Doğru Kelime: {_currentWord}");
                return false; // Kelime doğru tahmin edildi, oyun sonlanabilir.
            }
            else if (_maskedWord == _currentWord)
            {
                _score += 50;
                Render();
                Console.WriteLine($"{_tenSpaces}Tebrikler! Kelimeyi Doğru Tahmin Ettiniz!");
                // Todo : Yeni kelimeye geçiş yapılabilir.
                /*
                 * Yenbi kelimeye geçilir. Grup aynen korunur. Grup içerisinden yeni bir kelime seçilir. Aynı kelime olmamasına dikkat edilir.
                 * Yanlış sayısı sıfırlanır. Maskelenmiş kelime güncellenir.
                 */
                SaveBestScore(user.Value);
                return false;
            }

            return true;
        }

        private void SaveBestScore(UserProfile user)
        {
            if (_score < _bestScore) return;

            FileService fileService = new FileService();
            string path = Path.Combine("data", "Games", user._firstName);
            fileService.EnsureDirectory(path);

            string scoreJson = JsonSerializer.Serialize(_score);
            string filePath = Path.Combine(path, "bestscore.json");
            File.WriteAllText(filePath, scoreJson);
        }

        public void Render()
        {
            Console.Clear();
            Console.CursorVisible = false;

            Console.WriteLine($"{_tenSpaces}Kelime Grubu: {_selectedGroup} - Skor: {_score} - En İyi Skor: {_bestScore}\n");
            int currentFrameIndex = (HangmanAssets._frames.Length - 1) - (_maxWrongAttempts - _wrongAttempts);
            Console.WriteLine(HangmanAssets._frames[currentFrameIndex] + "\n");

            Console.WriteLine($"{_tenSpaces}Kelime: {_maskedWord} \n");

            Console.WriteLine($"{_tenSpaces}Tahmininiz İçin Bir Tuşa Basınız. (Oyunu sonlandırmak için Esc'ye basınız)");
        }

        public bool InitializeGame(UserProfile user)
        {
            _bestScore = GetBestScoreOrDefault(user);
            _score = 0;
            _wrongAttempts = 0;

            string[] wordGroups = HangmanAssets._groupedWords.Keys.ToArray();

            MenuService menuService = new MenuService("Lütfen Bir Kelime Grubu Seçiniz", wordGroups);
            int selectedIndex = menuService.DisplayMenu();

            //Todo: Eğer kullanıcı çıkış yaptıysa oyunu sonlandır.
            if (selectedIndex == -1)
                return false;

            _selectedGroup = wordGroups[selectedIndex];

            _words = HangmanAssets._groupedWords[_selectedGroup];
            Random random = new Random();
            _currentWord = _words[random.Next(0, _words.Length)];
            _maskedWord = new string('_', _currentWord.Length);


            return true;
        }

        public int GetBestScoreOrDefault(UserProfile user)
        {
            string path = Path.Combine("data", "Games", user._firstName);
            FileService fileService = new FileService();
            fileService.EnsureDirectory(path);
            string filePath = Path.Combine(path, "bestscore.json");
            if (File.Exists(filePath))
            {
                string scoreJson = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<int>(scoreJson);
            }
            else
            {
                return 0;
            }
        }
    }
}
