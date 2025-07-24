using Portfolio.API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class FakeContext
    {
        
            public List<ExperienceDto> Experiences { get; set; }

            public FakeContext()
            {
                Experiences = new List<ExperienceDto> { new ExperienceDto { Id = 1, CompanyName = "Fake Name", Description = "Fake Description", StartDate = new DateTime(2025, 1, 2), EndDate = new DateTime(2025, 7, 2), Role = "Fake ROle" } };
            }
        
    }
}
