namespace Portfolio.API.Models.DTOs
{
    public class MyProfileDto
    {
        public int Id { get; set; }                     // Unique identifier
        public string FullName { get; set; }            // Full name
        public string Title { get; set; }               // Job title (e.g., Full Stack Developer)
        public string Summary { get; set; }             // Brief personal summary
        public string Email { get; set; }               // Contact email
        public string Phone { get; set; }               // Phone number (optional)
        public string GitHubUrl { get; set; }           // GitHub profile URL
    }
}

