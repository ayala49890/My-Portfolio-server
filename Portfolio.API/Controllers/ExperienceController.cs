using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models.DTOs;
using Portfolio.API.Models.Post;
using Portfolio.Core.Entities;
using Portfolio.Core.Services;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;
        private readonly IMapper _mapper;
        public ExperienceController(IExperienceService experienceService, IMapper mapper)
        {
            _experienceService = experienceService;
            _mapper = mapper;
        }
        // GET: api/<ExperienceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var experiences = await _experienceService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ExperienceDto>>(experiences));

        }

        //// GET api/<ExperienceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var experience = await _experienceService.GetByIdAsync(id);
            if (experience == null)
                return NotFound();
            return Ok(experience);
        }

        // POST api/<ExperienceController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ExperiencePostModel experience)
        {
            var experienceToAdd = _mapper.Map<Experience>(experience);
            var addedExperience = await _experienceService.AddAsync(experienceToAdd);
            var newExperience = await _experienceService.GetByIdAsync(addedExperience.Id);
            var experienceDto = _mapper.Map<ExperienceDto>(newExperience);
            return Ok(experienceDto);
        }

        // PUT api/<ExperienceController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ExperiencePostModel experience)
        {
            var existExperience = await _experienceService.GetByIdAsync(id);
            if (existExperience is null)
                return NotFound();

            _mapper.Map(experience, existExperience); 
            await _experienceService.UpdateAsync(id, existExperience);
            return Ok(_mapper.Map<ExperienceDto>(existExperience));
        }


        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _experienceService.DeleteAsync(id);
            if (deleted == null)
                return NotFound();

            return Ok(deleted); 
        }

    }
}
