using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;

using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;


namespace Patholab_DAL_V1
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IEnumerable<T> GetAll1();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Save();
    }

    public abstract class GenericRepository<C, T> :
        IGenericRepository<T>
        where T : class
        where C : DbContext, new()
    {

        private C _entities = new C();
        public C Entities
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }
        public IEnumerable<T> GetAll1()
        {
            IQueryable<T> query = _entities.Set<T>();
            return query;
        }


        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }
        public IQueryable<T> FindByInclude(System.Linq.Expressions.Expression<Func<T, bool>> predicate,string Table4including)
        {

            IQueryable<T> query = _entities.Set<T>().Include(Table4including).Where(predicate);
            return query;
        }
        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}


