using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public interface IMyProfileService
    {
        Task<MyProfile> GetAsync();
        Task<MyProfile> UpdateAsync( MyProfile myProfile);
        Task<MyProfile> AddAsync(MyProfile myProfile);
    }

}
