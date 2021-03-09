﻿using AutoMapper;
using CarSeller.BusinessLogic.Interfaces;
using CarSeller.DataAccess.Interfaces;
using CarSeller.Entities.Models;
using CarSeller.ViewModels.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarSeller.BusinessLogic.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;

        public PurchaseService(IUnitOfWork database, 
                               IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }

        public async Task CreateAsync(PurchaseViewModel entity) 
        {
            var purchaseMapper = this.mapper.Map<Purchase>(entity);
            await this.database.Purchase.CreateAsync(purchaseMapper);
            await this.database.Save();
        }

        public async Task<ICollection<PurchaseInfoViewModel>> GetAllAsync() 
        {
            var purchases = await this.database.Purchase.GetAllAsync();
            return this.mapper.Map<ICollection<PurchaseInfoViewModel>>(purchases);
        }
    }
}