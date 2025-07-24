using AutoMapper;
using Portfolio.API.Models.DTOs;
using Portfolio.Core.Entities;
using Portfolio.Core.Repositories;
using Portfolio.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Service
{
    public class ExperienceService : IExperienceService
    {
        private readonly IExperienceRepository _experienceRepository;
        private readonly IMapper _mapper;

        public ExperienceService(IExperienceRepository repository, IMapper mapper)
        {
            _experienceRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<Experience>> GetAllAsync()
        {
            var data = await _experienceRepository.GetAllAsync();
            return _mapper.Map<List<Experience>>(data);
        }

        public async Task<Experience?> GetByIdAsync(int id)
        {
            var entity = await _experienceRepository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<Experience>(entity);
        }

        public async Task<Experience> AddAsync(Experience experience)
        {
            var entity = _mapper.Map<Experience>(experience);
            await _experienceRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Experience> UpdateAsync(int id, Experience experience)
        {
            var entity = _mapper.Map<Experience>(experience);
            entity.Id = id;
            await _experienceRepository.UpdateAsync(entity);
            return entity;
        }

        public async Task<Experience> DeleteAsync(int id)
        {
            return await _experienceRepository.DeleteAsync(id);
        }

        

        
    }

}
