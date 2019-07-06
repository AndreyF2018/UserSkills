using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DalInterface
{
   public interface ISkillDao
    {
       IEnumerable<Skill> GetAllSkills();
       IEnumerable<Skill> GetUserSkills(int _userId);
       string AddSkill(Skill skill);
       string AssignSkill(int _assignedUserId, int _assignedSkillId);
       string DeleteUserSkill(int _deletedUserId, int _deletedSkillId);
       IEnumerable<Skill> SearchSkill(string title);
       //void AddFromFileAwards();
      
    }
}
