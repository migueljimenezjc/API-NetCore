﻿using API.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Infrastructure.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        #region 'CREATE'
        T Create(T obj);
        Task<T> CreateAsync(T obj);
        IEnumerable<T> AddRange(IEnumerable<T> obj);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> obj);
        #endregion
        #region 'READ'
        IEnumerable<T> Read();
        Task<IEnumerable<T>> ReadAsync();
        Boolean Exist(Expression<Func<T, bool>> matchitem);
        Task<Boolean> ExistAsync(Expression<Func<T, bool>> matchitem);
        T Find(Expression<Func<T, bool>> matchitem); /*Single Item*/
        Task<T> FindAsync(Expression<Func<T, bool>> matchitem);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> matchitem); /*Many Items*/
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> matchitem);
        IEnumerable<T> FindAllWhere(Expression<Func<T, bool>> matchitem);
        Task<IEnumerable<T>> FindAllWhereAsync(Expression<Func<T, bool>> matchitem);
        IEnumerable<T> FindAllWhereTake(Expression<Func<T, bool>> matchitem, int count);
        Task<IEnumerable<T>> FindAllWhereTakeAsync(Expression<Func<T, bool>> matchitem, int count);
        IEnumerable<T> FindAllTake(int count);
        Task<IEnumerable<T>> FindAllTakeAsync(int count);
        T Get(int id);
        Task<T> GetAsync(int id);
        #endregion
        #region 'UPDATE'
        T Update(T obj);
        Task<T> UpdateAsync(T obj);
        #endregion
        #region 'DELETE'
        T Delete(T obj);
        Task<T> DeleteAsync(T obj);
        IEnumerable<T> DeleteRange(IEnumerable<T> obj);
        Task<IEnumerable<T>> DeleteRangeAsync(IEnumerable<T> obj);
        #endregion
        #region 'COUNT'
        int Count();
        Task<int> CountAsync();
        #endregion
        #region 'EXISTS'
        Boolean Exists(Expression<Func<T, bool>> matchitem);
        Task<Boolean> ExistsAsync(Expression<Func<T, bool>> matchitem);
        #endregion
    }
}
