using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using DAL.Interfaces;
using DomainModel;

namespace DAL
{
	public class GenericDataRepository<T>:IGenericDataRepository<T> where T:class, IEntity
	{
		public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
		{
			List<T> list;
			using (var context = new Entities())
			{
				IQueryable<T> dbQuery = context.Set<T>();

				foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
					dbQuery = dbQuery.Include<T, object>(navigationProperty);

				list = dbQuery
					.AsNoTracking()
					.ToList<T>();
			}
			return list;
		}

		public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
		{
			List<T> list;
			using (var context = new Entities())
			{
				IQueryable<T> dbQuery = context.Set<T>();

				foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
					dbQuery = dbQuery.Include<T, object>(navigationProperty);

				list = dbQuery
					.AsNoTracking()
					.Where(where)
					.ToList<T>();
			}
			return list;
		}

		public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
		{
			T item = null;
			using (var context = new Entities())
			{
				IQueryable<T> dbQuery = context.Set<T>();

				foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
					dbQuery = dbQuery.Include<T, object>(navigationProperty);

				item = dbQuery
					.AsNoTracking()
					.FirstOrDefault(where);
			}
			return item;
		}

		public virtual void Add(params T[] items)
		{
			Update(items);
			//using (var context = new Entities())
			//{
			//	foreach (T item in items)
			//	{
			//		context.Entry(item).State = System.Data.EntityState.Added;
			//	}
			//	context.SaveChanges();
			//}
		}

		public virtual void Update(params T[] items)
		{
			//using (var context = new Entities())
			//{
			//	foreach (T item in items)
			//	{
			//		context.Entry(item).State = System.Data.EntityState.Modified;
			//	}
			//	context.SaveChanges();
			//}

			using (var context = new Entities())
			{
				DbSet<T> dbSet = context.Set<T>();
				foreach (T item in items)
				{
					dbSet.Add(item);
					foreach (DbEntityEntry<IEntity> entry in context.ChangeTracker.Entries<IEntity>())
					{
						IEntity entity = entry.Entity;
						entry.State = GetEntityState(entity.EntityState);
					}
				}
				context.SaveChanges();
			}
		}

		public virtual void Remove(params T[] items)
		{
			Update(items);
			//using (var context = new Entities())
			//{
			//	foreach (T item in items)
			//	{
			//		context.Entry(item).State = System.Data.EntityState.Deleted;
			//	}
			//	context.SaveChanges();
			//}
		}

		protected static System.Data.EntityState GetEntityState(EntityState entityState)
		{
			switch (entityState)
			{
				case EntityState.Unchanged:
					return System.Data.EntityState.Unchanged;
				case EntityState.Added:
					return System.Data.EntityState.Added;
				case EntityState.Modified:
					return System.Data.EntityState.Modified;
				case EntityState.Deleted:
					return System.Data.EntityState.Deleted;
				default:
					return System.Data.EntityState.Detached;
			}
		}
	}
}
