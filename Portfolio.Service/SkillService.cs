using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.API.Models.DTOs;
using Portfolio.Core.Entities;
using Portfolio.Core.Repositories;
using Portfolio.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Service
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository repository, IMapper mapper)
        {
            _skillRepository = repository;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            var entities = await _skillRepository.GetAllAsync();
            return entities;
        }

        public async Task<Skill> GetByIdAsync(int id)
        {
            var entity = await _skillRepository.GetByIdAsync(id);
            return entity;
        }
        

        public async Task<Skill> AddAsync(Skill skill)
        {
            await _skillRepository.AddAsync(skill);
            return skill;
        }

        public async Task<Skill> UpdateAsync(int id, Skill skill)
        {
            var existSkill = await _skillRepository.GetByIdAsync(id);
            if (existSkill != null)
            {
                existSkill.Name = skill.Name;
                existSkill.Category = skill.Category;
                existSkill.IconUrl = skill.IconUrl;
              
            }

            await _skillRepository.UpdateAsync(existSkill);

            return existSkill;
        }


        public async Task<Skill> DeleteAsync(int id)
        {
           return await _skillRepository.DeleteAsync(id);
        }
    }

}
