using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Data.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _context;

        public SkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetAllAsync() =>
            await _context.Skills.ToListAsync();

        public async Task<Skill?> GetByIdAsync(int id) =>
            await _context.Skills.FindAsync(id);

        public async Task<Skill> AddAsync(Skill Skill)
        {
            _context.Skills.Add(Skill);
            await _context.SaveChangesAsync();
            return Skill;
        }

        public async Task<Skill> UpdateAsync(Skill Skill)
        {
            _context.Skills.Update(Skill);
            await _context.SaveChangesAsync();
            return Skill;
        }

        public async Task<Skill> DeleteAsync(int id)
        {
            var entity = await _context.Skills.FindAsync(id);
            if (entity != null)
            {
                _context.Skills.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }
    }

}
