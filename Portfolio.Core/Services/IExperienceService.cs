using Portfolio.API.Models.DTOs;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public interface IExperienceService
    {
        Task<List<Experience>> GetAllAsync();
        Task<Experience?> GetByIdAsync(int id);
        Task<Experience> AddAsync(Experience experience);
        Task<Experience> UpdateAsync(int id, Experience experience);
        Task<Experience> DeleteAsync(int id);
    }

}
