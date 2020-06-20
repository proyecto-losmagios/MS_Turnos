using System.Collections.Generic;
using System.Linq;


namespace Domain.Commands {
    public interface IGenericsRepository {
        void Add<T>(T entity) where T : class;
        IQueryable<T> GetAll<T>() where T : class;
        T FindById<T>(int id) where T : class;
    }
}