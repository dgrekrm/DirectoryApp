using System.Linq.Expressions;

namespace DirectoryApp.DataAccessLayer.BaseModels {
    public interface IRepository<T> where T : class, new() {
        Task Create(T entity);
        Task Update(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);
        Task<T> Find(string id);
        Task SaveChanges();
    }
}
