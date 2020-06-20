
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Domain.Commands;


namespace AccessData.Commands {

    public class GenericsRepository : IGenericsRepository {
        private readonly APIDbContext _context;

        public GenericsRepository (APIDbContext dbContext) {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class {
            _context.Add(entity);
            _context.SaveChanges();
        }
    
        public IQueryable<T> GetAll<T>() where T : class {
            return _context.Set<T>();
        }

        public T FindById<T>(int id) where T : class {
            return _context.Set<T>().Find(id);
        }
    }
}