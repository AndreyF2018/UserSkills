using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BLInterface
{
    public interface IUserLogic
    {
        IEnumerable<User> GetAllUsers();
        string Add(User user);
        void EditUserName(User user, string newName);
        string EditUserPassword(User user, string newPassword);
        int UserAuthentication(string login, string password);
        User GetUserById(int id);
        User GetUserByLogin(string login);
    }
}

