/*
using Core.Entities;
using Core.Interfaces;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _Context;
        public UserRepository(SocialMediaContext context)
        {
            _Context = context;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _Context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user;

        }

    }
}
*/