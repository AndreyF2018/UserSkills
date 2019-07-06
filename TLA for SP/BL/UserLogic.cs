using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BLInterface;
using DAL;
using DalInterface;

namespace BL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao userDao;

        public UserLogic()
        {
            this.userDao = new UserDao();
        }
        //public void AddFromDB()
        //{
        //    this.userDao.AddFromDB();
        //}

        public string Add(User user)
        {
            return this.userDao.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return this.userDao.GetAllUsers();
        }

        public void EditUserName(User user, string newName)
        {
            this.userDao.EditUserName(user, newName);
        }

        public string EditUserPassword(User user, string newPassword)
        {
            return this.userDao.EditUserPassword(user, newPassword);
        }

        public int UserAuthentication(string login, string password)
        {
            return this.userDao.UserAuthentication(login, password);
        }

        public User GetUserById(int id)
        {
            return this.userDao.GetUserById(id);
        }

        public User GetUserByLogin(string login)
        {
            return this.userDao.GetUserByLogin(login);
        }

        //public IEnumerable<User> Delete()
        //{
        //    return this.userDao.Delete();
        //}
        //public IEnumerable<User> Sort()
        //{
        //    return this.userDao.Sort();
        //}

        //public IEnumerable<User> SearchByName(string firstName)
        //{
        //    var users = this.userDao.GetAllUsers();
        //    var result = new List<User>();

        //    foreach (var currentUser in users)
        //    {
        //        if(currentUser.FirstName == firstName)
        //        {
        //            result.Add(currentUser);
        //        }
        //    }

        //    return result;
        //}
    }
}
