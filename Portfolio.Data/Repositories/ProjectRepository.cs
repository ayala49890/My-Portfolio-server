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
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects
                .Include(p => p.Technologies)
                    .ThenInclude(pt => pt.Skill)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .Include(p => p.Technologies)
                    .ThenInclude(pt => pt.Skill)
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Project> AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteAsync(int id)
        {
            var entity = await _context.Projects
                .Include(p => p.Technologies)  // טען את הרשומות התלויות
                .FirstOrDefaultAsync(p => p.Id == id);

            if (entity != null)
            {
                // מחק את כל הקישורים לטבלאות המשניות קודם
                if (entity.Technologies != null)
                {
                    _context.ProjectSkills.RemoveRange(entity.Technologies);
                }

                _context.Projects.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

    }

}
