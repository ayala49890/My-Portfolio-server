using AutoMapper;
using Portfolio.API.Models.DTOs;
using Portfolio.Core.Entities;
using Portfolio.Core.Repositories;
using Portfolio.Core.Services;
using Portfolio.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Service
{
    public class MyProfileService : IMyProfileService
    {
        private readonly IMyProfileRepository _myProfileRepository;

        public MyProfileService(IMyProfileRepository repository)
        {
            _myProfileRepository = repository;
        }

        public async Task<MyProfile> AddAsync(MyProfile myProfile)
        {
            await _myProfileRepository.AddAsync(myProfile);
            return myProfile;
        }

        public async Task<MyProfile> GetAsync()
        {
            return ( await _myProfileRepository.GetAsync());
        }

        public async Task<MyProfile> UpdateAsync(MyProfile myProfile)
        {
            var existProfile = await _myProfileRepository.GetAsync();
            if (existProfile != null)
            {
                existProfile.Email = myProfile.Email;
                existProfile.Title = myProfile.Title;
                existProfile.Phone = myProfile.Phone;
                existProfile.FullName = myProfile.FullName;
                existProfile.Summary = myProfile.Summary;
                existProfile.GitHubUrl = myProfile.GitHubUrl;

            }

            await _myProfileRepository.UpdateAsync(existProfile);

            return existProfile;
        }

      
    }
}
