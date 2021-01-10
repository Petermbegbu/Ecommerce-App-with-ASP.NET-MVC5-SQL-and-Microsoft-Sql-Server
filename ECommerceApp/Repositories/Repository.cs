using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ECommerceApp.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public List<TEntity> GetProduct()
        {
            return _context.Set<TEntity>().ToList();
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public int GetAllCount()
        {
            return _context.Set<TEntity>().Count();
        }

        public IQueryable<TEntity> GetAllIQueryable()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetFirstOrDefault(int recordId)
        {
            return _context.Set<TEntity>().Find(recordId);
        }

        public TEntity GetFirstOrDefaultByParameter(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetListParameter(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetResultBySqlProcedure(string query, params object[] parameters)
        {
            if(parameters != null)
            {
                return _context.Database.SqlQuery<TEntity>(query, parameters).ToList();
            }
            else
            {
                return _context.Database.SqlQuery<TEntity>(query).ToList();
            }
        }

        public void InactiveAndDeleteMarkByWhereClause(Expression<Func<TEntity, bool>> predicate, Action<TEntity> forEachPredicate)
        {
            _context.Set<TEntity>().Where(predicate).ToList().ForEach(forEachPredicate);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveByWhereClause(Expression<Func<TEntity, bool>> predicate)
        {
            TEntity entity = _context.Set<TEntity>().Where(predicate).FirstOrDefault();
            Remove(entity);
        }

        public void RemoveRangeByWhereClause(Expression<Func<TEntity, bool>> predicate)
        {
            List<TEntity> entity = _context.Set<TEntity>().Where(predicate).ToList();

            foreach (var ent in entity)
            {
                Remove(ent);
            }
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void UpdateByWhereClause(Expression<Func<TEntity, bool>> predicate, Action<TEntity> forEachPredicate)
        {
            _context.Set<TEntity>().Where(predicate).ToList().ForEach(forEachPredicate);
        }

        public IEnumerable<TEntity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> OrderBypredicate)
        {
            if(predicate != null)
            {
                return _context.Set<TEntity>().OrderBy(OrderBypredicate).Where(predicate).ToList();
            }
            else
            {
                return _context.Set<TEntity>().OrderBy(OrderBypredicate).ToList();
            }
        }

    }
}