using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Abstract
{
    /// <summary>
    /// Interface for CRUD-logic
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseLogic<T, TEntity> where TEntity : class where T : class
    {
        T Get(int id);
        void Create(T item);
        void Update(T item);
        bool Delete(int id);
        void Save();
    }
}
