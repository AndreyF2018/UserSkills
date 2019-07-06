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
    public class SkillLogic : ISkillLogic
    {
        private ISkillDao skillDao;

        public SkillLogic()
        {
            this.skillDao = new SkillDao();
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return this.skillDao.GetAllSkills();
        }

        public IEnumerable<Skill> GetUserSkills(int _userId)
        {
            return this.skillDao.GetUserSkills(_userId);
        }

        public string AddSkill(Skill skill)
        {
            return this.skillDao.AddSkill(skill);
        }

        public string AssignSkill(int _assignedUserId, int _assignedSkillId)
        {
            return this.skillDao.AssignSkill(_assignedUserId, _assignedSkillId);
        }

        public string DeleteUserSkill(int _deletedUserId, int _deletedSkillId)
        {
            return this.skillDao.DeleteUserSkill(_deletedUserId, _deletedSkillId);
        }

        public IEnumerable<Skill> SearchSkill(string title)
        {
            return this.skillDao.SearchSkill(title);
        }


        //public void AddFromFileAwards()
        //{
        //    this.awardDao.AddFromFileAwards();
        //}

        //public IEnumerable<Skill> Delete()
        //{
        //    return this.skillDao.DeleteUserSkill();
        //}


    }
}
