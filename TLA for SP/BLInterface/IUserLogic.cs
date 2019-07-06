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
        /*
        IEnumerable<User> GetAll();
        void AddFromFile();
        int Add(User value);
        IEnumerable<User> Delete();
        IEnumerable<User> Sort();
        IEnumerable<User> SearchByName(string firstName);
        */
        
        IEnumerable<User> GetAllUsers();
        //void AddFromDB();
        string Add(User user);
        //IEnumerable<User> Delete();
        //IEnumerable<User> Sort();
        void EditUserName(User user, string newName);
        string EditUserPassword(User user, string newPassword);
        int UserAuthentication(string login, string password);
        User GetUserById(int id);
        User GetUserByLogin(string login);
    }
}

