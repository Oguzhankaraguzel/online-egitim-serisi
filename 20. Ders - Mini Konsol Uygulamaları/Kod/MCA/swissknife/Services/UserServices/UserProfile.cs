using System;

namespace swissknife.Services.UserServices
{
    public struct UserProfile
    {
        public string _firstName;
        public string _lastName;
        public string _email;
        public DateTime? _dateOfBirth;
        public ConsoleColor _foreground;
        public ConsoleColor _background;
    }
}
