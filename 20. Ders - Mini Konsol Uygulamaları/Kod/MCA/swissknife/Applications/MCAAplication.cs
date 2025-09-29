using swissknife.Services.UserServices;
using System;

namespace swissknife.Applications
{
    public struct MCAAplication
    {
        public void Run()
        {
            UserService userService = new UserService();
            Greetings(userService);

            // Menü ile ana uygulama işlevselliği burada başlatılabilir
            userService.DisplayUserInfo();

            Console.WriteLine("Çıkmak için bir tuşa basın...");
            Console.ReadKey();
        }

        /// <summary>
        /// Bu metod kullanıcıyı karşılamak için hazırlanmıştır. Kullanıcı yoksa yeni kullanıcı oluşturulmasını sağlar.
        /// Ardından kullanıcı ayarlarını yapılandırarak hoşgeldin mesajı gösterir. 
        /// </summary>
        public void Greetings(UserService userService)
        {
            UserProfile? user = userService.GetUser();
            if (user == null)
            {
                Console.WriteLine("Kullanıcı bulunamadı. Yeni kullanıcı oluşturuluyor... Devam Etmek İçin Bir Tuşa Basın");
                Console.ReadKey();
                userService.CreateUser();
            }
            else
            {
                userService.ApplyUserSettings();
                Console.WriteLine("Hoşgeldin {0} {1}", user.Value._firstName, user.Value._lastName);
                Console.WriteLine("Devam Etmek İçin Bir Tuşa Basın");
                Console.ReadKey();
            }
        }
    }
}
