using System.Windows;
using Patholab_Common;
using Patholab_DAL_V1;
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
    internal class Repository//<TEntity> where TEntity : class
    {

        internal static DbSet<TEntity> GetAll<TEntity>(Entities context) where TEntity : class
        {
            var q = context.Set<TEntity>();
            return q;
        }
        internal static IQueryable<TEntity> GetAllInclude<TEntity>(Entities context, string tableToInclude) where TEntity : class
        {

            IQueryable<TEntity> query = context.Set<TEntity>().Include(tableToInclude);
            return query;
        }
        internal static IQueryable<TEntity> FindBy<TEntity>(Entities context, Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {

            IQueryable<TEntity> query = context.Set<TEntity>().Where(predicate);
            return query;
        }
        internal static IQueryable<TEntity> FindByInclude<TEntity>(Entities context, Expression<Func<TEntity, bool>> predicate, string tableToInclude) where TEntity : class
        {

            IQueryable<TEntity> query = context.Set<TEntity>().Include(tableToInclude).Where(predicate);
            return query;
        }
        internal static void Add<TEntity>(Entities context, TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Add(entity);
        }


        internal static void Edit<TEntity>(Entities context, TEntity entity) where TEntity : class
        {
            context.Entry(entity).State = System.Data.EntityState.Modified;
        }


        internal static void Delete<TEntity>(Entities context, TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Remove(entity);
        }

        internal static decimal GetNewId(Entities context, string sequenceName)
        {
            try
            {



                var newId = context.Database.SqlQuery<decimal>("select lims." + sequenceName + ".nextval from dual");
                return newId.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Logger.WriteLogFile(ex);

                throw ex;
                //                return 0;
            }
        }



    }
}