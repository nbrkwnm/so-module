using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SOModule.Domain.Core.Interfaces.Repositories;

namespace SOModule.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        void IBaseRepository<TEntity>.Add(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IBaseRepository<TEntity>.Remove(TEntity entity)
        {
            try
            {
                _context.Entry(entity).Property("IsActive").CurrentValue = false;
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void IBaseRepository<TEntity>.Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        IEnumerable<TEntity> IBaseRepository<TEntity>.GetAll()
        {
            var query = _context.Set<TEntity>().ToList();

            return query ?? new List<TEntity>();
        }

        TEntity IBaseRepository<TEntity>.GetById(int id)
        {
            var query = _context.Set<TEntity>().Find(id);

            return query ?? null;
        }
    }
}