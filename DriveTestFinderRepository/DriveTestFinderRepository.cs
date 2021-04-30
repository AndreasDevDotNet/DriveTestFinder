using DriveTestFinderRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DriveTestFinderRepository
{
    public class DriveTestFinderRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private DriveTestFinderMasterContext _dbContext;

        public DriveTestFinderRepository(string connectionString)
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

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
