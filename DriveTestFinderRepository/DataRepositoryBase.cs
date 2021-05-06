using DriveTestFinderRepository.Entities;
using EFCore.BulkExtensions;
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

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().Where(where);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
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

        public async Task Add(TEntity entity, bool saveChanges = false)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            if(saveChanges)  await _dbContext.SaveChangesAsync();
        }

        public async Task AddMany(IList<TEntity> entities)
        {
            await _dbContext.BulkInsertAsync(entities);
        }

        public async Task DeleteMany(IList<TEntity> entities)
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
    }
}
