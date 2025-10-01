using swissknife.Services.Extensions;
using swissknife.Services.UserServices;
using System;

namespace swissknife.Applications
{
    public struct MCAAplication
    {
        public void Run()
        {
            UserService userService = new UserService();
            Greetings(ref userService);

            // Menü ile ana uygulama işlevselliği burada başlatılabilir
            UserProfile? user = userService.GetUser();
            if (user != null)
            {
                userService.UpdateUser(user.Value);
                user = userService.GetUser(); 
                userService.ApplyUserSettings(user.Value);
                userService.DisplayUserInfo(user.Value);
            }
            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
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
