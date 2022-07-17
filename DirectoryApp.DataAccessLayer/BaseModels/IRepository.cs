namespace DirectoryApp.DataAccessLayer.BaseModels {
    public interface IRepository<T> where T : class, new() {
        Task Create(T entity);
        Task Update(T entity);
        IEnumerable<T> GetAll();
        Task SaveChanges();
    }
}
