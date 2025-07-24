using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill> GetByIdAsync(int id);
        Task<Skill> AddAsync(Skill skill);
        Task<Skill> UpdateAsync(Skill skill);
        Task<Skill> DeleteAsync(int id);
    }

}
