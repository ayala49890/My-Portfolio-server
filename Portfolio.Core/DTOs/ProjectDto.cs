using Portfolio.Core.Entities;

namespace Portfolio.API.Models.DTOs
{

    public class ProjectDto
    {
        public int Id { get; set; }                      // Unique identifier
        public string Name { get; set; }                 // Project name
        public string Description { get; set; }          // Short description
        public string Url { get; set; }                   // URL to project or source code
        public string? ImageUrl { get; set; }                   // URL to project or source code
        public DateTime StartDate { get; set; }           // Project start date
        public DateTime? EndDate { get; set; }             // Project end date (nullable)
        public List<ProjectSkill> Technologies { get; set; }    // List of technologies used (e.g., ["React", "ASP.NET Core"])
    }
}
