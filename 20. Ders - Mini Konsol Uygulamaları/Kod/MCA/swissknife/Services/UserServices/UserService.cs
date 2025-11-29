using swissknife.Services.Extensions;
using swissknife.Services.FileServices;
using System;
using System.IO;
using System.Text.Json;

namespace swissknife.Services.UserServices
{
    public struct UserService
    {
        public const string _dataDir = "data";
        public const string _userFile = "user.json";
        public static string _userPath = Path.Combine(_dataDir, _userFile);
        public static JsonSerializerOptions _serializeOption = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        /// <summary>
        /// Kullanıcı bilgilerini JSON formatında kaydeder.
        /// </summary>
        /// <param name="user"></param>
        public void SaveUser(UserProfile user)
        {
            FileService fileService = new FileService();

            string jsonString = JsonSerializer.Serialize(user, _serializeOption);
            fileService.EnsureDirectory(_dataDir);
            File.WriteAllText(_userPath, jsonString);
        }

        /// <summary>
        /// Eğer kullanıcı bilgileri mevcutsa, JSON dosyasından okuyarak UserProfile nesnesi olarak döner.
        /// </summary>
        /// <returns></returns>
        public UserProfile? GetUser()
        {
            FileService fileService = new FileService();
            fileService.EnsureDirectory(_dataDir);

            if (!File.Exists(_userPath))
            {
                return null;
            }

            string userJson = File.ReadAllText(_userPath);
            return JsonSerializer.Deserialize<UserProfile>(userJson, _serializeOption);
        }

        /// <summary>
        /// Kullanıcıdan konsol üzerinden bilgi alarak yeni bir kullanıcı profili oluşturur ve kaydeder.
        /// </summary>
        public void CreateUser()
        {
            Console.Clear();
            UserProfile user = new UserProfile();

            Console.WriteLine("Ad: ");
            user._firstName = Console.ReadLine() ?? "";
            Console.WriteLine("Soyad: ");
            user._lastName = Console.ReadLine() ?? "";
            Console.WriteLine("E-posta: ");
            user._email = Console.ReadLine() ?? "";
            Console.WriteLine("Doğum Tarihi (GG.AA.YYYY): ");

            DateTime? dateOfBirth = null;
            try
            {
                dateOfBirth = DateTime.Parse(Console.ReadLine() ?? "");
            }
            catch
            {
                Console.WriteLine("Geçersiz tarih formatı. Doğum tarihi boş bırakıldı. Daha sonra güncelleyebilirsiniz");
            }
            user._dateOfBirth = dateOfBirth;

            Console.WriteLine("Konsol Yazı Rengi (örnek: Red, Green, Blue): ");
            if (Enum.TryParse<ConsoleColor>(Console.ReadLine() ?? "", true, out ConsoleColor foreground))
            {
                user._foreground = foreground;
            }
            else
            {
                user._foreground = ConsoleColor.White;
                Console.WriteLine("Geçersiz renk. Yazı rengi varsayılan olarak beyaz ayarlandı.");
            }

            Console.WriteLine("Konsol Arka Plan Rengi (örnek: Black, DarkBlue, DarkGray): ");
            if (Enum.TryParse<ConsoleColor>(Console.ReadLine() ?? "", true, out ConsoleColor background))
            {
                user._background = background;
            }
            else
            {
                user._background = ConsoleColor.Black;
                Console.WriteLine("Geçersiz renk. Arka plan rengi varsayılan olarak siyah ayarlandı.");
            }

            SaveUser(user);
            ConsoleEx.Pause();
        }

        /// <summary>
        /// Kullanıcıdan konsol üzerinden bilgi alarak mevcut kullanıcı profilini günceller ve kaydeder.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(UserProfile user)
        {
            Console.Clear();
            UserProfile userProfile = new UserProfile();

            Console.WriteLine("Kullanıcı bilgilerini güncelleyin. Mevcut bilgileri değiştirmeden bırakmak için Enter'a basın.");

            Console.WriteLine("Ad (mevcut: {0}): ", user._firstName);
            userProfile._firstName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userProfile._firstName))
                userProfile._firstName = user._firstName;
            

            Console.WriteLine("Soyad (mevcut: {0}): ", user._lastName);
            userProfile._lastName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userProfile._lastName))
                userProfile._lastName = user._lastName;

            Console.WriteLine("E-posta (mevcut: {0}): ", user._email);
            userProfile._email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userProfile._email))
                userProfile._email = user._email;

            Console.WriteLine("Doğum Tarihi (GG.AA.YYYY) (mevcut: {0}): ", user._dateOfBirth?.ToString("dd.MM.yyyy") ?? "Boş");

            string dobInput = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(dobInput))
            {
                userProfile._dateOfBirth = user._dateOfBirth;
            }
            else
            {
                try
                {
                    userProfile._dateOfBirth = DateTime.Parse(dobInput);
                }
                catch
                {
                    userProfile._dateOfBirth = user._dateOfBirth;
                    Console.WriteLine("Geçersiz tarih formatı. Doğum tarihi güncellenmedi.");
                }
            }

            Console.WriteLine("Konsol Yazı Rengi (örnek: Red, Green, Blue) (mevcut: {0}): ", user._foreground);
            string fgInput = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(fgInput))
            {
                userProfile._foreground = user._foreground;
            }
            else if (Enum.TryParse<ConsoleColor>(fgInput, true, out ConsoleColor foreground))
            {
                userProfile._foreground = foreground;
            }
            else
            {
                userProfile._foreground = user._foreground;
                Console.WriteLine("Geçersiz renk. Yazı rengi güncellenmedi.");
            }
            Console.WriteLine("Konsol Arka Plan Rengi (örnek: Black, DarkBlue, DarkGray) (mevcut: {0}): ", user._background);
            string bgInput = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(bgInput))
            {
                userProfile._background = user._background;
            }
            else if (Enum.TryParse<ConsoleColor>(bgInput, true, out ConsoleColor background))
            {
                userProfile._background = background;
            }
            else
            {
                userProfile._background = user._background;
                Console.WriteLine("Geçersiz renk. Arka plan rengi güncellenmedi.");
            }

            SaveUser(userProfile);
            ConsoleEx.Pause();
        }

        /// <summary>
        /// Kısaca, kullanıcı ayarlarını konsola uygular.
        /// </summary>
        /// <param name="user"></param>
        public void ApplyUserSettings(UserProfile user)
        {
            Console.ForegroundColor = user._foreground;
            Console.BackgroundColor = user._background;
        }


        /// <summary>
        /// Kullanıcı bilgilerini konsola yazdırır.
        /// </summary>
        /// <param name="user"></param>
        public void DisplayUserInfo(UserProfile user)
        {
            Console.Clear();
            Console.WriteLine("Kullanıcı Bilgileri:");
            Console.WriteLine("Ad: {0}", user._firstName);
            Console.WriteLine("Soyad: {0}", user._lastName);
            Console.WriteLine("E-posta: {0}", user._email);
            Console.WriteLine("Doğum Tarihi: {0}", user._dateOfBirth?.ToString("dd.MM.yyyy") ?? "Boş");
            Console.WriteLine("Yazı Rengi: {0}", user._foreground);
            Console.WriteLine("Arka Plan Rengi: {0}", user._background);
            ConsoleEx.Pause();
        }
    }
}
