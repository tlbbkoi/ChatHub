﻿using ChatBE.Data;
using ChatBE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using X.PagedList;

namespace ChatBE.Reponsitory
{
    public class GenericRespository
    {
        public class GenericRepository<T> : IGenericRespository<T> where T : class
        {
            private readonly DatabaseContext _context;
            private readonly DbSet<T> _db;

            public GenericRepository(DatabaseContext context)
            {
                _context = context;
                _db = _context.Set<T>();
            }

            public async Task Delete(int id)
            {
                var entity = await _db.FindAsync(id);
                _db.Remove(entity);
            }

            public void DeleteRange(IEnumerable<T> entities)
            {
                _db.RemoveRange(entities);
            }

            public async Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            {
                IQueryable<T> query = _db;
                if (include != null)
                {
                    query = include(query);
                }

                return await query.AsNoTracking().FirstOrDefaultAsync(expression);
            }

            public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
            {
                IQueryable<T> query = _db;

                if (expression != null)
                {
                    query = query.Where(expression);
                }

                if (includes != null)
                {
                    foreach (var includePropery in includes)
                    {
                        query = query.Include(includePropery);
                    }
                }

                if (orderBy != null)
                {
                    query = orderBy(query);
                }

                return await query.AsNoTracking().ToListAsync();
            }

            public async Task<X.PagedList.IPagedList<T>> GetPagedList(RequestParams requestParams, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
            {
                IQueryable<T> query = _db;


                if (include != null)
                {
                    query = include(query);
                }

                return await query.AsNoTracking()
                    .ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);
            }

            public IQueryable<T> GetQuery()
            {
                return _db;
            }

            public async Task Insert(T entity)
            {
                await _db.AddAsync(entity);
            }

            public async Task InsertRange(IEnumerable<T> entities)
            {
                await _db.AddRangeAsync(entities);
            }

            public void Update(T entity)
            {
                _db.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            Task<PagedList.IPagedList<T>> IGenericRespository<T>.GetPagedList(RequestParams requestParams, Func<IQueryable<T>, IIncludableQueryable<T, object>> include)
            {
                throw new NotImplementedException();
            }
        }
    }
}
