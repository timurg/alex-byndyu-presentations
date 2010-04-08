using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure;

namespace Domain.MyOrmImplementation
{
    public class MyOrmDataContext : IDataContext
    {
        #region IDataContext Members

        public IQueryable<T> Query<T>()
        {
            return (IQueryable<T>) new List<Product>
                                       {
                                           new Product
                                               {
                                                   Name = "Одуванчик полевой, лекарственный",
                                                   ShowCount = 30
                                               }
                                       }.AsQueryable();
        }

        public void Save<T>(T entity)
        {
        }

        public void Delete<T>(T entity)
        {
        }

        public T Get<T>(int id)
        {
            return default(T);
        }

        #endregion
    }
}