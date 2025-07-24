namespace Portfolio.API.Models.Post
{
    public class ExperiencePostModel
    {
        public string CompanyName { get; set; }
        public string Role { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string? Link { get; set; }
        public string? IconUrl { get; set; }
        public string Location { get; set; }
    }
}
