using DriveTestFinderRepository.Entities;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DriveTestFinderRepository
{
    public abstract class DataRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        private DriveTestFinderMasterContext _dbContext;

        public DataRepositoryBase(string connectionString)
        {
            _dbContext = new DriveTestFinderMasterContext(connectionString);
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().Where(where).ToList();
        }

        public List<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> FindQueryable(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().Where(where);
        }

        public IQueryable<TEntity> GetAllQueryable()
        {
            return _dbContext.Set<TEntity>();
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(where);
        }

        public async Task AddAsync(TEntity entity, bool saveChanges = false)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            if(saveChanges)  await _dbContext.SaveChangesAsync();
        }

        public void Add(TEntity entity, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (saveChanges) _dbContext.SaveChanges();
        }

        public void AddMany(IList<TEntity> entities)
        {
            _dbContext.BulkInsert(entities);
        }
        public async Task AddManyAsync(IList<TEntity> entities)
        {
            await _dbContext.BulkInsertAsync(entities);
        }

        public void UpdateMany(IList<TEntity> entities)
        {
            _dbContext.BulkUpdate(entities);
        }

        public async Task UpdateManyAsync(IList<TEntity> entities)
        {
            await _dbContext.BulkUpdateAsync(entities);
        }

        public async Task DeleteManyAsync(IList<TEntity> entities)
        {
            await _dbContext.BulkDeleteAsync(entities);
        }

        public async Task DeleteManyWhere(Expression<Func<TEntity, bool>> where)
        {
            await _dbContext.Set<TEntity>().Where(where).BatchDeleteAsync();
        }

        public async Task Delete(TEntity entity, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (saveChanges) await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void DisableChangeTracking()
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void EnableChangeTracking()
        {
            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
        }
    }
}
