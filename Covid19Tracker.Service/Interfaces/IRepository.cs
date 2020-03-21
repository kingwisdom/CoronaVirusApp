using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Covid19Tracker.Service.Interfaces
{
    public interface IRepository<T> where T: class
    {
        ICollection<T> GetAll();

        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(Guid id);
        public ICollection<T> FindAll(Expression<Func<T, bool>> match);
        
    }
}
