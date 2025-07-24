using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Portfolio.Data.Repositories
{
    public class MyProfileRepository : IMyProfileRepository
    {
        private readonly AppDbContext _context;

        public MyProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<MyProfile> AddAsync(MyProfile myProfile)
        {
            _context.Profiles.Add(myProfile);
            _context.SaveChanges();
            return Task.FromResult(myProfile);
        }

        public async Task<MyProfile> GetAsync()
        {
            return await _context.Profiles.FirstOrDefaultAsync();
        }

        public async Task<MyProfile> UpdateAsync(MyProfile profile)
        {
            _context.Profiles.Update(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

    }

}
