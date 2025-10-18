﻿using swissknife.Services.Extensions;
using swissknife.Services.MenuServices;
using swissknife.Services.UserServices;
using System;

namespace swissknife.Applications
{
    public struct MCAAplication
    {
        public static string[] _menuItems = new string[]
        {
            "Kullanıcı Bilgilerini Görüntüle",
            "Kullanıcı Bilgilerini Güncelle",
            "Notlar",
            "Çıkış"
        };
        public void Run()
        {
            UserService userService = new UserService();
            Greetings(ref userService);
            UserProfile? user = userService.GetUser();
            bool running = true;
            while (running)
            {
                int index = ShowMenuAndGetSelectedIndex();

                switch (index)
                {
                    case 0:
                        userService.DisplayUserInfo(user.Value);
                        break;
                    case 1:
                        userService.UpdateUser(user.Value);
                        user = userService.GetUser();
                        userService.ApplyUserSettings(user.Value);
                        break;
                    case 2:
                        NoteApp noteApp = new NoteApp();
                        noteApp.Run();
                        break;
                    case 3:
                    case -1:
                        running = !ConsoleEx.ConfirmExit();
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Güle Güle");
            ConsoleEx.Pause();
        }

        private int ShowMenuAndGetSelectedIndex()
        {
            MenuService menuService = new MenuService("Ana Menü", _menuItems);
            return menuService.DisplayMenu();
        }

        /// <summary>
        /// Bu metod kullanıcıyı karşılamak için hazırlanmıştır. Kullanıcı yoksa yeni kullanıcı oluşturulmasını sağlar.
        /// Ardından kullanıcı ayarlarını yapılandırarak hoşgeldin mesajı gösterir. 
        /// </summary>
        public void Greetings(ref UserService userService)
        {
            UserProfile? user = userService.GetUser();
            if (user == null)
            {
                Console.WriteLine("Kullanıcı bulunamadı. Yeni kullanıcı oluşturuluyor...");
                ConsoleEx.Pause();
                userService.CreateUser();
            }
            else
            {
                userService.ApplyUserSettings(user.Value);
                Console.WriteLine("Hoşgeldin {0} {1}", user.Value._firstName, user.Value._lastName);
                ConsoleEx.Pause();
            }
        }
    }
}
