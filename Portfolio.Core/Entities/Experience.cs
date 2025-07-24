using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Entities
{
    public class Experience
    {
        public int Id { get; set; }
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
