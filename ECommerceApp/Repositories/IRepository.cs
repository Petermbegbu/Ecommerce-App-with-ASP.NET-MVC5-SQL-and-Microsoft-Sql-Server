using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ECommerceApp.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        int GetAllCount();
        List<TEntity> GetAll();
        List<TEntity> GetProduct();
        IQueryable<TEntity> GetAllIQueryable();
        TEntity GetFirstOrDefault(int recordId);
        TEntity GetFirstOrDefaultByParameter(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetListParameter(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetResultBySqlProcedure(string query, params object[] parameters);
        IEnumerable<TEntity> GetRecordsToShow(int PageNo, int PageSize, int CurrentPage, 
                Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, int>> OrderBypredicate);

        void Add(TEntity entity);

        void Update(TEntity entity);
        void UpdateByWhereClause(Expression<Func<TEntity, bool>> predicate, Action<TEntity> forEachPredicate);

        void Remove(TEntity entity);
        void RemoveByWhereClause(Expression<Func<TEntity, bool>> predicate);
        void RemoveRangeByWhereClause(Expression<Func<TEntity, bool>> predicate);

        void InactiveAndDeleteMarkByWhereClause(Expression<Func<TEntity, bool>> predicate, Action<TEntity> forEachPredicate);
    }
}