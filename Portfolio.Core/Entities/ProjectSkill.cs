using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Entities
{
    public class ProjectSkill
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SkillId { get; set; }    
        public Skill Skill { get; set; }

    }
}
