﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Interfaces
{
    public interface IOperations<T> where T : class
    {
        #region'CREATE'
        T Create(T Data);
        IEnumerable<T> AddRange(IEnumerable<T> Data);
        IEnumerable<T> AddRangeAsync(IEnumerable<T> Data);
        #endregion
        #region'READ'
        T Read(T Data);
        T Find(Expression<Func<T, bool>> matchitem);
        IEnumerable<T> FindAllWhere(Expression<System.Func<T, bool>> matchitem);
        IEnumerable<T> FindAllWhereTake(Expression<System.Func<T, bool>> matchitem, int count);
        IEnumerable<T> FindAllTake(int count);
        Task<T> ReadAsync(T Data);
        Task<T> FindAsync(Expression<Func<T, bool>> matchitem);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> matchitem);
        Task<IEnumerable<T>> FindAllTakeAsync(int count);
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> matchitem);
        #endregion
        #region 'UPDATE'
        T Update(T Data);
        T UpdateAsync(T Data);
        #endregion
        #region'DELETE'
        T Delete(T Data);
        #endregion
        #region'COUNT'
        int Count();
        Task<int> CountAsync();
        #endregion
        #region'EXISTS'
        Task<bool> ExistsAsync(Expression<Func<T, bool>> matchitem);
        bool Exists(Expression<Func<T, bool>> matchitem);
        #endregion
    }
}
