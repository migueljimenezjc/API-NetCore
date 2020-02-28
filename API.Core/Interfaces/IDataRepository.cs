using API.Entities.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Core.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Get(string param1, string param2);
        int Count(long id);
        void Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        void Delete(int id);
        ResponseAPI Validate(TEntity receipt);
    }
}
