using Portfolio.Core.Entities;

namespace Portfolio.API.Models.Post
{
    public class ProjectPostModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
