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
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _projectRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            var data = await _projectRepository.GetAllAsync();
            return  _mapper.Map<List<Project>>(data);
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var entity = await _projectRepository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<Project>(entity);
        }

        public async Task<Project> AddAsync(Project project)
        {
            var entity = _mapper.Map<Project>(project);
            await _projectRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Project> UpdateAsync(int id, Project project)
        {
            var entity = _mapper.Map<Project>(project);
            entity.Id = id;
            await _projectRepository.UpdateAsync(entity);
            return entity;
        }

        public async Task<Project> DeleteAsync(int id)
        {
           return await _projectRepository.DeleteAsync(id);
        }

       
    }

}
