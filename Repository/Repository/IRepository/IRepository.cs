﻿using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IRepository<TModel> where TModel: class, IBaseModel
    {
        Task<TModel> AddAsync(TModel model);
        Task<DbSet<TModel>> GetAllAsync();
        Task DeleteAsync(int id);
        Task<TModel> GetAsyncById(int id);
        Task<IQueryable<TModel>> GetWithRelationAsyncById(int id);
    }
}
