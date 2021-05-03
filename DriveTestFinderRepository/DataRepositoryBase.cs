using DriveTestFinderRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public TEntity FindOne(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().SingleOrDefault(where);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().Add(entity);
            if(saveChanges) _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity, bool saveChanges = false)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (saveChanges) _dbContext.SaveChanges();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
