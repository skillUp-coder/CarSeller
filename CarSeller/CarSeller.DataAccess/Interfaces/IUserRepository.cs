﻿using CarSeller.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User entity);

        Task<ICollection<User>> GetAllAsync();
    }
}
