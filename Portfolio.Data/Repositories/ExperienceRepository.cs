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
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly AppDbContext _context;

        public ExperienceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Experience>> GetAllAsync() =>
            await _context.Experiences.ToListAsync();

        public async Task<Experience?> GetByIdAsync(int id) =>
            await _context.Experiences.FindAsync(id);

        public async Task<Experience> AddAsync(Experience experience)
        {
            _context.Experiences.Add(experience);
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task<Experience> UpdateAsync(Experience experience)
        {
            _context.Experiences.Update(experience);
            await _context.SaveChangesAsync();
            return experience;
        }

        public async Task<Experience> DeleteAsync(int id)
        {
            var entity = await _context.Experiences.FindAsync(id);
            if (entity is not null)
            {
                _context.Experiences.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

    }

}
