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

        public void SaveUser(UserProfile user)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(user, _serializeOption);
                if (!Directory.Exists(_dataDir))
                {
                    Directory.CreateDirectory(_dataDir);
                }
                File.WriteAllText(_userPath, jsonString);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserProfile? GetUser()
        {
            try
            {
                UserProfile? user = null;
                if (Directory.Exists(_dataDir))
                {
                    string userJson = File.ReadAllText(_userPath);
                    user = JsonSerializer.Deserialize<UserProfile>(userJson, _serializeOption);
                }
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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
            ApplyUserSettings();
        }

        public void UpdateUser()
        {
            Console.Clear();
            UserProfile? user = GetUser();
            if (user == null)
            {
                CreateUser();
            }
            else
            {
                UserProfile userProfile = new UserProfile();

                Console.WriteLine("Kullanıcı bilgilerini güncelleyin. Mevcut bilgileri değiştirmeden bırakmak için Enter'a basın.");
                Console.WriteLine("Ad (mevcut: {0}): ", user.Value._firstName);
                userProfile._firstName = Console.ReadLine() ?? user.Value._firstName;

                Console.WriteLine("Soyad (mevcut: {0}): ", user.Value._lastName);
                userProfile._lastName = Console.ReadLine() ?? user.Value._lastName;

                Console.WriteLine("E-posta (mevcut: {0}): ", user.Value._email);
                userProfile._email = Console.ReadLine() ?? user.Value._email;

                Console.WriteLine("Doğum Tarihi (GG.AA.YYYY) (mevcut: {0}): ", user.Value._dateOfBirth?.ToString("dd.MM.yyyy") ?? "Boş");

                string dobInput = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(dobInput))
                {
                    userProfile._dateOfBirth = user.Value._dateOfBirth;
                }
                else
                {
                    try
                    {
                        userProfile._dateOfBirth = DateTime.Parse(dobInput);
                    }
                    catch
                    {
                        userProfile._dateOfBirth = user.Value._dateOfBirth;
                        Console.WriteLine("Geçersiz tarih formatı. Doğum tarihi güncellenmedi.");
                    }
                }

                Console.WriteLine("Konsol Yazı Rengi (örnek: Red, Green, Blue) (mevcut: {0}): ", user.Value._foreground);
                string fgInput = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(fgInput))
                {
                    userProfile._foreground = user.Value._foreground;
                }
                else if (Enum.TryParse<ConsoleColor>(fgInput, true, out ConsoleColor foreground))
                {
                    userProfile._foreground = foreground;
                }
                else
                {
                    userProfile._foreground = user.Value._foreground;
                    Console.WriteLine("Geçersiz renk. Yazı rengi güncellenmedi.");
                }
                Console.WriteLine("Konsol Arka Plan Rengi (örnek: Black, DarkBlue, DarkGray) (mevcut: {0}): ", user.Value._background);
                string bgInput = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(bgInput))
                {
                    userProfile._background = user.Value._background;
                }
                else if (Enum.TryParse<ConsoleColor>(bgInput, true, out ConsoleColor background))
                {
                    userProfile._background = background;
                }
                else
                {
                    userProfile._background = user.Value._background;
                    Console.WriteLine("Geçersiz renk. Arka plan rengi güncellenmedi.");
                }

                SaveUser(userProfile);
                ApplyUserSettings();
            }
        }

        public void ApplyUserSettings()
        {
            UserProfile? user = GetUser();
            if (user != null)
            {
                Console.ForegroundColor = user.Value._foreground;
                Console.BackgroundColor = user.Value._background;
            }
            else
            {
                Console.WriteLine("Kullanıcı bulunamadı. Lütfen önce bir kullanıcı oluşturun.");
            }
        }

        public void DisplayUserInfo()
        {
            Console.Clear();
            UserProfile? user = GetUser();
            if (user != null)
            {
                Console.WriteLine("Kullanıcı Bilgileri:");
                Console.WriteLine("Ad: {0}", user.Value._firstName);
                Console.WriteLine("Soyad: {0}", user.Value._lastName);
                Console.WriteLine("E-posta: {0}", user.Value._email);
                Console.WriteLine("Doğum Tarihi: {0}", user.Value._dateOfBirth?.ToString("dd.MM.yyyy") ?? "Boş");
                Console.WriteLine("Yazı Rengi: {0}", user.Value._foreground);
                Console.WriteLine("Arka Plan Rengi: {0}", user.Value._background);
            }
            else
            {
                Console.WriteLine("Kullanıcı bulunamadı. Lütfen önce bir kullanıcı oluşturun.");
            }
        }
    }
}
