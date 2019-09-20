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
    class SkillLogicPL
    {
        private static ISkillLogic skillLogic = new SkillLogic();
        public static void GetAllSkills()
        {
            foreach (var item in skillLogic.GetAllSkills())
            {
                Console.WriteLine(item);
            }
        }

        public static void GetUserSkills(int id)
        {
            if (skillLogic.GetUserSkills(id) != null)
            {
                foreach (var item in skillLogic.GetUserSkills(id))
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("У пользователя ещё нет навыков");
            }
        }




        public static void AddSkill()
        {
            Console.WriteLine("Введите название навыка");
            var title = Console.ReadLine();

            Console.WriteLine("Введите описание навыка");
            var description = Console.ReadLine();

            var currentSkill = new Skill()
            {
                skillTitle = title,
                skillDescription = description
            };

            string result = skillLogic.AddSkill(currentSkill);
            Console.WriteLine(result);

        }

        public static void AssignSkill(int _assignedUserId)
        {
            Console.WriteLine("Введите id навыка для присвоения");
            int _assignedSkillId = int.Parse(Console.ReadLine());
            string result = skillLogic.AssignSkill(_assignedUserId, _assignedSkillId);
            Console.WriteLine(result);
        }

        public static void DeleteUserSkill(int _deletedUserId)
        {
            Console.WriteLine("Введите id навыка для удаления");
            int _deletedSkillId = int.Parse(Console.ReadLine());
            string result = skillLogic.DeleteUserSkill(_deletedUserId, _deletedSkillId);
            Console.WriteLine(result);
        }

        public static void SearchSkill()
        {
            Console.WriteLine("Введите название навыка для поиска");
            var title = Console.ReadLine();
            if (skillLogic.SearchSkill(title) == null)
            {
                Console.WriteLine("навык не найден");
            }
            else
            {
                foreach (var item in skillLogic.SearchSkill(title))
                {                 
                        Console.WriteLine(item);
                }
            }

        }
    }
}
