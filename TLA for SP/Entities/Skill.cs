using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Skill
    {
        public int skillId { get; set; }
        public string skillTitle { get; set; }
        public string skillDescription { get; set; }

        public Skill()
        {

        }
        public Skill(string _skillTitle, string _skillDescription)
        {
            skillTitle = _skillTitle;
            skillDescription = _skillDescription;
        }

        public override string ToString()
        {
            string result = skillId.ToString() + " " + skillTitle + " " + skillDescription;
            return result;
        }

    }
}
