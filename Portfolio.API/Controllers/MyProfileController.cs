using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models.Post;
using Portfolio.Core.Entities;
using Portfolio.Core.Services;
using Portfolio.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyProfileController : ControllerBase
    {
        private readonly IMyProfileService _myProfileService;
        public MyProfileController(IMyProfileService myProfileService)
        {
            _myProfileService = myProfileService;
        }
        // GET: api/<ProfileController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok( await _myProfileService.GetAsync());
        }

        // POST api/<SkillsController>
       // [HttpPost]
        //public async Task<ActionResult> Post([FromBody] MyProfilePostModel myProfile)
        //{
        //    var profileToAdd = new MyProfile { Email = myProfile.Email,
        //        Phone = myProfile.Phone,
        //        Title = myProfile.Title,
        //        FullName = myProfile.FullName,
        //        Summary = myProfile.Summary,
        //        GitHubUrl = myProfile.GitHubUrl
        //    };
        //    return Ok(await _myProfileService.AddAsync(profileToAdd));

        //}

        // PUT api/<ProfileController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MyProfilePostModel myProfile)
        {
            var existingMyProfile = await _myProfileService.GetAsync();
            if (existingMyProfile == null)
                return NotFound();

            existingMyProfile.Title = myProfile.Title;
            existingMyProfile.Phone = myProfile.Phone;
            existingMyProfile.Email = myProfile.Email;
            existingMyProfile.FullName = myProfile.FullName;
            existingMyProfile.Summary = myProfile.Summary;
            existingMyProfile.GitHubUrl = myProfile.GitHubUrl;

            await _myProfileService.UpdateAsync(existingMyProfile);

            return Ok(existingMyProfile);
        }

    }
}
