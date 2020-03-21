using Covid19Tracker.Data.DataContext;
using Covid19Tracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Covid19Tracker.Service.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Covid19TrackerDBContext covid19TrackerDBContext;
        

        public Repository(Covid19TrackerDBContext covid19TrackerDBContext)
        {
            this.covid19TrackerDBContext = covid19TrackerDBContext;
        }
        public void Delete(Guid id)
        {
            var entity = this.covid19TrackerDBContext.Set<T>().Find(id);

            this.covid19TrackerDBContext.Set<T>().Remove(entity);
            this.covid19TrackerDBContext.SaveChanges();

        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return this.covid19TrackerDBContext.Set<T>().Where(match).ToList();
        }


        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            this.covid19TrackerDBContext.Set<T>().Add(entity);
            this.covid19TrackerDBContext.SaveChanges();

        }

        public void Update(T entity)
        {
            this.covid19TrackerDBContext.Set<T>().Update(entity);
            this.covid19TrackerDBContext.SaveChanges();
        }

      public  ICollection<T> GetAll()
        {
            return this.covid19TrackerDBContext.Set<T>().ToList();

        }
    }
}
