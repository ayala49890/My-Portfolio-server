using Portfolio.API.Models.DTOs;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public interface ISkillService
    {
        Task<List<Skill>> GetAllAsync();
        Task<Skill?> GetByIdAsync(int id);
        Task<Skill> AddAsync(Skill skill);
        Task<Skill> UpdateAsync(int id, Skill skill);
        Task<Skill> DeleteAsync(int id);
    }

}
