using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;
using System.Linq.Expressions;

namespace DirectoryApp.DataAccessLayer.Repositories {
    public class MemberRepository : IRepository<Member> {

        private readonly TableContext _tableContext;

        public MemberRepository(TableContext tableContext) {
            _tableContext = tableContext;
        }

        public async Task Create(Member entity) {
            entity.CreateDate = DateTime.Now;
            await _tableContext.Members.AddAsync(entity);
        }

        public IEnumerable<Member> GetAll() {
            return _tableContext.Members.ToList();
        }

        public async Task<Member> Find(string id) {
            return await _tableContext.Members.FindAsync(id);
        }

        public async Task SaveChanges() {
            await _tableContext.SaveChangesAsync();
        }

        public async Task Update(Member entity) {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> Get(Expression<Func<Member, bool>> expression) {
            throw new NotImplementedException();
        }
    }
}
