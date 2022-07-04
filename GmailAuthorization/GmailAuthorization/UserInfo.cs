using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAuthorization
{
    public class UserInfo
    {
        private readonly string _stackOverflowUrl = "https://stackoverflow.com/";
        private readonly string _email = "test123@gmail.com";
        private readonly string _invalidPassword = "testtest123";

        public string StackOverflowUrl => _stackOverflowUrl;
        public string Email => _email;
        public string InvalidPassword => _invalidPassword;
    }
}
