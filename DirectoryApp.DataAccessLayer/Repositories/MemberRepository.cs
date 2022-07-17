using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;

namespace DirectoryApp.DataAccessLayer.Repositories {
    public class MemberRepository : IRepository<Member> {

        private readonly TableContext _tableContext;

        public MemberRepository(TableContext tableContext) {
            _tableContext = tableContext;
        }

        public async Task Create(Member entity) {
            await _tableContext.Members.AddAsync(entity);
        }

        public IEnumerable<Member> GetAll() {
            return _tableContext.Members.ToList();
        }

        public async Task SaveChanges() {
            await _tableContext.SaveChangesAsync();
        }

        public async Task Update(Member entity) {
            throw new NotImplementedException();
        }
    }
}
