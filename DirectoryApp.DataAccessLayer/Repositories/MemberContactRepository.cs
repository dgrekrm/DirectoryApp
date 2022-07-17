using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;

namespace DirectoryApp.DataAccessLayer.Repositories {
    public class MemberContactRepository : IRepository<MemberContact> {

        private readonly TableContext _tableContext;

        public MemberContactRepository(TableContext tableContext) {
            _tableContext = tableContext;
        }

        public async Task Create(MemberContact entity) {
            await _tableContext.MemberContacts.AddAsync(entity);
        }

        public IEnumerable<MemberContact> GetAll() {
            return _tableContext.MemberContacts.ToList();
        }

        public async Task SaveChanges() {
            await _tableContext.SaveChangesAsync();
        }

        public async Task Update(MemberContact entity) {
            throw new NotImplementedException();
        }
    }
}
