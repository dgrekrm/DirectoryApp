namespace DirectoryApp.DataAccessLayer.BaseModels {
    public interface IRepository<T> where T : class, new() {
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
