using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using BLInterface;
using Entities;
using System.IO;

namespace TLA
{
    public static class UserLogicPL
    {

        private static IUserLogic userLogic = new UserLogic();
        
        public static void Add()
        {
            Console.WriteLine("Введите имя");
            var name = Console.ReadLine();

            Console.WriteLine("Введите логин");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль");
            var password = Console.ReadLine();


            var currentUser = new User()
            {
                userName = name,
                userLogin = login,
                userPassword = password

            };

            string result = userLogic.Add(currentUser);
            Console.WriteLine(result);
        }

        public static void GetAllUsers()
        {
            foreach (var item in userLogic.GetAllUsers())
            {
                Console.WriteLine(item); 
            }
        }

        public static void EditUserName(int id)
        {
            if (id > 0)
            {
                User currentUser = new User();
                currentUser = userLogic.GetUserById(id);
                Console.WriteLine("Введите новое имя: ");
                var newName = Console.ReadLine();

                userLogic.EditUserName(currentUser, newName);
            }
            else
            {
                Console.WriteLine("Данные введены неверно"); 
            }
          
        }

        public static void EditUserPassword(int id)
        {
            User currentUser = new User();
            currentUser = userLogic.GetUserById(id);
            Console.WriteLine("Введите новый пароль: ");
            var newPassword = Console.ReadLine();

            string result = userLogic.EditUserPassword(currentUser, newPassword);
            Console.WriteLine(result);
            
        }

        public static int UserAuthentication()
        {
            Console.WriteLine("Авторизация");
            Console.WriteLine("Введите логин: ");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            var password = Console.ReadLine();

            User currentUser = new User();
            currentUser = userLogic.GetUserByLogin(login);
            return userLogic.UserAuthentication(login, password);
        }
    }
}