using AutoMapper;
using Portfolio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace Portfolio.Core.Repositories
{
    public interface IMyProfileRepository
    {
        Task<MyProfile> GetAsync();
        Task<MyProfile> AddAsync(MyProfile myProfile);
        Task<MyProfile> UpdateAsync(MyProfile myProfile);
    }

}
