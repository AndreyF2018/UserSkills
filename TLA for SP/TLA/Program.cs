using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLA
{
    class Program
    {
        static void Main(string[] args)
        {
            int authorizedId = -1;
            Console.WriteLine("1 - Авторизироваться");
            Console.WriteLine("2 - Зарегистрироваться");
            Console.WriteLine("3 - Вывести всех пользователей");
            Console.WriteLine("4 - Изменить имя пользователя");
            Console.WriteLine("5 - Изменить пароль пользователя");
            Console.WriteLine("6 - Вывести все навыки");
            Console.WriteLine("7 - Вывести навыки одного пользователя");
            Console.WriteLine("8 - Добавить навык в базу данных");
            Console.WriteLine("9 - Присвоить пользователю навык");
            Console.WriteLine("10 - Удалить навык у пользователя");
            Console.WriteLine("11 - Поиск навыков");
            Console.WriteLine("12 - Разлогиниться");
            while (true)
            {
                Console.WriteLine("Введите действие");
                var action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        authorizedId =  UserLogicPL.UserAuthentication();
                        if (authorizedId == -1)
                        {
                            Console.WriteLine("Неправильный логин или пароль");
                        }
                        else
                        {
                            Console.WriteLine("Вы успешно авторизовались");
                        }
                        break;
                    case "2":
                        UserLogicPL.Add();
                        break;
                    case "3":
                        UserLogicPL.GetAllUsers();
                        break;
                    case "4":
                        if (authorizedId == -1)
                        {
                           // authorizedId = UserLogicPL.UserAuthentication();
                            goto case "1";
                        }
                        UserLogicPL.EditUserName(authorizedId);
                        break;
                    case "5":
                         if (authorizedId == -1)
                        {
                            //authorizedId = UserLogicPL.UserAuthentication();
                            goto case "1";
                        }
                        UserLogicPL.EditUserPassword(authorizedId);
                        break;
                    case "6":
                        SkillLogicPL.GetAllSkills();
                        break;
                    case "7":
                        if (authorizedId == -1)
                        {
                            //authorizedId = UserLogicPL.UserAuthentication();
                            goto case "1";

                        }
                        SkillLogicPL.GetUserSkills(authorizedId);
                        break;
                    case "8":
                        SkillLogicPL.AddSkill();
                        break;
                    case "9":
                        if (authorizedId == -1)
                        {
                            //authorizedId = UserLogicPL.UserAuthentication();
                            goto case "1";
                        }
                        SkillLogicPL.AssignSkill(authorizedId);
                        break;
                    case "10":
                        if (authorizedId == -1)
                        {
                            //authorizedId = UserLogicPL.UserAuthentication();
                            goto case "1";
                        }
                        SkillLogicPL.DeleteUserSkill(authorizedId);
                        break;
                    case "11":
                        SkillLogicPL.SearchSkill();
                        break;
                    case "12":
                        if (authorizedId == -1)
                        {
                            Console.WriteLine("Вы не авторизовались");
                        }
                        else
                        {
                            authorizedId = -1;
                            Console.WriteLine("Вы вышли из учётной записи");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
