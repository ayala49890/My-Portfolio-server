using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models.DTOs;
using Portfolio.API.Models.Post;
using Portfolio.Core.Entities;
using Portfolio.Core.Services;
using Portfolio.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly ISkillService _skillService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper, ISkillService skillService)
        {
            _projectService = projectService;
            _mapper = mapper;
            _skillService = skillService;
        }


        // GET: api/<ProjectsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.GetAllAsync();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            var projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }


        // POST api/<ProjectsController>

        // [HttpPost]
        //public async Task<ActionResult> Post([FromBody] ProjectPostModel project)
        //{
        //    var projectToAdd = _mapper.Map<Project>(project);
        //    var addedProject = await _projectService.AddAsync(projectToAdd);
        //    var newProject = await _projectService.GetByIdAsync(addedProject.Id);
        //    var projectDto = _mapper.Map<ProjectDto>(newProject);
        //    return Ok(projectDto);
        //}
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProjectPostModel projectModel)
        {
            var projectToAdd = new Project
            {
                Name = projectModel.Name,
                Description = projectModel.Description,
                Url = projectModel.Url,
                StartDate = projectModel.StartDate,
                EndDate = projectModel.EndDate,
                Technologies = new List<ProjectSkill>(),
                ImageUrl = projectModel.ImageUrl
            };

            var skills = new List<Skill>();

            foreach (var skillId in projectModel.SkillIds)
            {
                var skill = await _skillService.GetByIdAsync(skillId);
                if (skill != null)
                {
                    skills.Add(skill);
                }
            }

            foreach (var skill in skills)
            {
                projectToAdd.Technologies.Add(new ProjectSkill
                {
                    SkillId = skill.Id
                });
            }

            var addedProject = await _projectService.AddAsync(projectToAdd);
            var newProject = await _projectService.GetByIdAsync(addedProject.Id);
            var projectDto = _mapper.Map<ProjectDto>(newProject);
            return Ok(projectDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProjectPostModel projectModel)
        {
            var existingProject = await _projectService.GetByIdAsync(id);
            if (existingProject == null)
                return NotFound();

            // עדכון שדות בסיסיים
            existingProject.Name = projectModel.Name;
            existingProject.Description = projectModel.Description;
            existingProject.Url = projectModel.Url;
            existingProject.StartDate = projectModel.StartDate;
            existingProject.EndDate = projectModel.EndDate;
            existingProject.ImageUrl = projectModel.ImageUrl;

            // ניקוי רשימת הטכנולוגיות הקיימות
            existingProject.Technologies.Clear();

            // שליפת הסקילים החדשים והוספתם לרשימת הטכנולוגיות
            foreach (var skillId in projectModel.SkillIds)
            {
                var skill = await _skillService.GetByIdAsync(skillId);
                if (skill != null)
                {
                    existingProject.Technologies.Add(new ProjectSkill
                    {
                        SkillId = skill.Id
                    });
                }
            }

            await _projectService.UpdateAsync(id, existingProject);

            var updatedProject = await _projectService.GetByIdAsync(id);
            var projectDto = _mapper.Map<ProjectDto>(updatedProject);

            return Ok(projectDto);
        }




        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _projectService.DeleteAsync(id);
            if(deleted == null)
                return NotFound();
            return Ok(deleted);
        }
    }
}
