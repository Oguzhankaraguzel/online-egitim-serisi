using swissknife.Services.Extensions;
using swissknife.Services.FileServices;
using swissknife.Services.MenuServices;
using swissknife.Services.UserServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace swissknife.Applications
{
    public struct NoteApp
    {
        public const string _dataDir = "data";
        public const string _documentDir = "UserDocuments";
        public static string _userDocumentsPath = Path.Combine(_dataDir, _documentDir);
        public const string _documentExt = ".txt";
        public const string _appName = "Notes";
        public static string[] _menuOptions = new string[]
        {
            "Yeni Not Oluştur",
            "Notları Görüntüle",
            //"Notları Sil" // ödev. silinme işlemi eklenebilir.
        };
        public List<string> _documents;

        /// <summary>
        /// Not uygulamasını başlatır. Kullanıcıyı doğrular ve menü üzerinden
        /// yeni not oluşturma veya mevcut notları düzenleme işlemlerini yönetir.
        /// </summary>
        public void Run()
        {
            UserService userService = new UserService();
            UserProfile? user = userService.GetUser();

            if (!user.HasValue)
                throw new Exception("Kullanıcı bulunamadı.");

            MenuService menuService = new MenuService(_appName, _menuOptions);

            bool running = true;
            while (running)
            {
                int selectedIndex = menuService.DisplayMenu();
                switch (selectedIndex)
                {
                    case 0:
                        CreateNewNote(user.Value);
                        break;
                    case 1:
                        UpdateNote(user.Value);
                        break;
                    case -1:
                        running = !ConsoleEx.ConfirmExit();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Kullanıcının notlarının bulunduğu klasörü listeler. 
        /// Mevcut notları menü şeklinde gösterir ve seçilen not için düzenleme ekranını açar.
        /// </summary
        private void UpdateNote(UserProfile user)
        {
            Console.Clear();
            FileService fileService = new FileService();
            fileService.EnsureDirectory(_userDocumentsPath);
            string userDir = Path.Combine(_userDocumentsPath, user._firstName);
            fileService.EnsureDirectory(userDir);
            string[] documents = fileService.GetAllFilesInDirectory(userDir, _documentExt);

            string[] documentsName = new string[documents.Length];

            for (int i = 0; i < documents.Length; i++)
            {
                documentsName[i] = Path.GetFileName(documents[i]);
            }

            MenuService menuService = new MenuService("Dokümanlarım", documentsName);

            bool running = true;
            while (running)
            {
                int selectedIndex = menuService.DisplayMenu();
                switch (selectedIndex)
                {
                    case -1:
                        running = false;
                        break;
                    default:
                        EditFile(selectedIndex, documents);
                        break;
                }
            }
        }

        /// <summary>
        /// Seçilen dosyanın içeriğini okur, çok satırlı düzenleme ekranında kullanıcıya sunar 
        /// ve güncellenmiş içeriği dosyaya geri yazar.
        /// </summary>
        public void EditFile(int selectedIndex, string[] documents)
        {
            string content = File.ReadAllText(documents[selectedIndex]);

            string updatedContent = ConsoleEx.ReadMultiLine(documents[selectedIndex], content);

            File.WriteAllText(documents[selectedIndex], updatedContent);
        }

        /// <summary>
        /// Kullanıcıdan dosya adı ve içerik alarak yeni bir not dosyası oluşturur.
        /// Kullanıcıya özel klasörü kontrol eder ve gerekirse oluşturur.
        /// </summary>
        private void CreateNewNote(UserProfile user)
        {
            Console.Clear();
            Console.WriteLine("Dosya Adı: ");
            string documentName = Console.ReadLine();
            // dosya uzantısı girilmemiş olması gerekiyor. Eğer girilmişse temizlenmeli. Ödev
            FileService fileService = new FileService();
            fileService.EnsureDirectory(_userDocumentsPath);
            string userDir = Path.Combine(_userDocumentsPath, user._firstName);
            fileService.EnsureDirectory(userDir);
            string documentPath = Path.Combine(userDir, (documentName + _documentExt));

            string content = ConsoleEx.ReadMultiLine(documentName);

            File.WriteAllText(documentPath, content);
        }
    }
}
