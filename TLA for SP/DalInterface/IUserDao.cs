using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace DalInterface
{
    public interface IUserDao
    {
        IEnumerable<User> GetAllUsers(); // вывод всех пользователей
        string Add(User user); // добавление пользователя
        void EditUserName(User user, string newName); // редактирование имени
        string EditUserPassword(User user, string newPassword); // редактирование пароля
        int UserAuthentication(string login, string password); // аутентификация пользователя
        User GetUserById(int id); // вывод пользователя по его Id 
        User GetUserByLogin(string login); // вывод пользователя по его логину 
    }
}
