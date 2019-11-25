﻿using Microsoft.EntityFrameworkCore;
using RpaCrudLibrary.Interfaces.IRepositories;
using RpaCrudLibrary.Models;
using RpaCrudLibrary.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RpaCrudLibrary.Repositories
{
    public class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity : Component
    {
        private readonly RpaContext _rpaContext;

        public BaseRepository(RpaContext rpaContext)
        {
            _rpaContext = rpaContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = (await _rpaContext.Set<TEntity>().AddAsync(entity)).Entity;

            await _rpaContext.SaveChangesAsync();

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            var component = _rpaContext.Set<TEntity>().Where((c) => c.Id == id).FirstOrDefault();

            _rpaContext.Remove<TEntity>(component);

            await _rpaContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _rpaContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetOneByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _rpaContext.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var component = _rpaContext.Set<TEntity>().Update(entity).Entity;

            await _rpaContext.SaveChangesAsync();

            return component;
        }
    }
}
