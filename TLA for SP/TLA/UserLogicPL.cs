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

        //public static void AddFromFileAwards()
        //{
        //    awardLogic.AddFromFileAwards();
        //    List<int> temp = new List<int>();
        //    int c = 0;
        //    foreach (var itemUser in userLogic.GetAll())
        //    {

        //        c = 0;
        //        foreach (var itemAward in awardLogic.GetAll())
        //        {

        //            if (itemUser.Id == itemAward.Id && c == 0)
        //            {
        //                Console.WriteLine(itemUser + " " + itemAward.title);
        //                itemUser.award = itemAward.title;
        //                c = 1;
        //                temp.Add(itemAward.Id);

        //            }
        //            else if (itemUser.Id != itemAward.Id && c == 0 && temp.Any(item => item != itemAward.Id))
        //            {
        //                Console.WriteLine(itemUser);
        //                c = 1;
        //            }
        //        }
        //    }
        //}

        //public static void AddFromFile()
        //{ 
        //    userLogic.AddFromDB();
        //}
        
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
        /*
        public static void AddAward()
        {
            Console.WriteLine("Введите ID");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите название награды");
            var awardTtitle = Console.ReadLine();
 
            var currentAward = new Award()
            {
                Id = id,
                title = awardTtitle,
            };
            awardLogic.Add(currentAward);
            foreach (var itemUser in userLogic.GetAllUsers())
            {
                if (itemUser.Id == id)
                {
                    itemUser.award = awardTtitle;
                }
            }

        }
        */

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



        /*
        public static void Delete()
        {
            foreach (var item in userLogic.Delete())
            {
                Console.WriteLine(item);
            }

            foreach (var item in awardLogic.Delete())
            {
                Console.WriteLine(item);
            }

        }
        */
        //public static void Sort()
        //{

        //    foreach (var item in userLogic.Sort())
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //public static void SearchByName(string value)
        //{
        //    var result = userLogic.SearchByName(value).ToList();
        //    Console.WriteLine(result[0]);


        //}

        //public static void WriteInFile()
        //{
        //    using (StreamWriter sw = new StreamWriter("output.txt"))
        //    {
        //        foreach (var item in userLogic.GetAllUsers())
        //        {
        //            sw.WriteLine(item);
        //        }
        //        Console.WriteLine("Данные были записаны в файл");
        //    }
        //}
    }
}