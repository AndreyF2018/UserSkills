using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        
        public int? userId { get; set; }

        public string userName {get; set; }

        public string userLogin { get; set; }

        public string userPassword {get; set;}

        public User()
        {

        }
        public User(string _userName, string _userLogin, string _userPassword)
        {
            userName = _userName;
            userLogin = _userLogin;
            userPassword = _userPassword;
        }

		public override string ToString()
		{
            string result = userId.ToString() + " " + userName + " " + userLogin;
            return result;
		}
    }
}
