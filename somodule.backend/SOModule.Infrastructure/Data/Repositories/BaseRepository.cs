using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SOModule.Domain.Core.Interfaces.Repositories;
using SOModule.Domain.Models;

namespace SOModule.Infrastructure.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            try
            {
                _context.Entry(entity).Property("CreatedAt").CurrentValue = DateTime.Now;
                _context.Entry(entity).Property("IsActive").CurrentValue = true;
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Remove(TEntity entity)
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

        public void Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).Property("UpdatedAt").CurrentValue = DateTime.Now;
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            var query = _context.Set<TEntity>().ToList();

            return query ?? new List<TEntity>();
        }

        public TEntity GetById(int id)
        {
            var query = _context.Set<TEntity>().Find(id);

            return query ?? null;
        }
    }
}