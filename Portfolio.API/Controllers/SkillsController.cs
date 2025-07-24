using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models.Post;
using Portfolio.Core.Entities;
using Portfolio.Core.Services;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        { 
            _skillService = skillService;
        }
        
        // GET: api/<SkillsController>
        [HttpGet]
        public async Task<ActionResult<List<Skill>>> Get()
        {
            return Ok(await _skillService.GetAllAsync());
        }

        //// GET api/<SkillsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var skill = await _skillService.GetByIdAsync(id);
            if (skill == null) 
                return NotFound();
            return Ok(skill);
        }

        // POST api/<SkillsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SkillPostModel skill)
        {
            var skillToAdd = new Skill { Name = skill.Name, Category = skill.Category, IconUrl = skill.IconUrl };
            return Ok(await _skillService.AddAsync(skillToAdd));

        }

   
        // PUT api/<SkillsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] SkillPostModel skillModel)
        {
            var existingSkill = await _skillService.GetByIdAsync(id);
            if (existingSkill == null)
                return NotFound();

            existingSkill.Name = skillModel.Name;
            existingSkill.Category = skillModel.Category;
            existingSkill.IconUrl = skillModel.IconUrl;

            await _skillService.UpdateAsync(id, existingSkill);

            return Ok(existingSkill);
        }

        // DELETE api/<SkillsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedSkill = await _skillService.DeleteAsync(id);
            if (deletedSkill == null)
                return NotFound();

            return Ok(deletedSkill);
        }


    }
}
