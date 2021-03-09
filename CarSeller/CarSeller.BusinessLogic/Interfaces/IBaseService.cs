﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<ICollection<TEntity>> GetAllAsync();
    }
}