using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Repositories
{
    public interface IExperienceRepository
    {
        Task<List<Experience>> GetAllAsync();
        Task<Experience?> GetByIdAsync(int id);
        Task<Experience> AddAsync(Experience experience);
        Task<Experience> UpdateAsync(Experience experience);
        Task<Experience> DeleteAsync(int id);
    }

}
