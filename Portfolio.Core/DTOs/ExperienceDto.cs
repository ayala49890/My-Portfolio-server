namespace Portfolio.API.Models.DTOs
{
    public class ExperienceDto
    {
        public int Id { get; set; }                        // Unique identifier
        public string CompanyName { get; set; }            // Company name
        public string Role { get; set; }                    // Job title / role
        public DateTime StartDate { get; set; }             // Start date
        public DateTime? EndDate { get; set; }               // End date (nullable if currently employed)
        public string? Link { get; set; }                   // Link to company or project (optional)
        public string? IconUrl { get; set; }                // Icon URL (optional, e.g., company logo)
        public string Description { get; set; }              // Role description / achievements
        public string? Location { get; set; }                // Location of the job (optional, e.g., city, country)

    }
}
