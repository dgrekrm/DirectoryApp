using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;
using System.Linq.Expressions;

namespace DirectoryApp.DataAccessLayer.Repositories {
    public class MemberContactRepository : IRepository<MemberContact> {

        private readonly TableContext _tableContext;

        public MemberContactRepository(TableContext tableContext) {
            _tableContext = tableContext;
        }

        public async Task Create(MemberContact entity) {
            entity.CreateDate = DateTime.Now;
            await _tableContext.MemberContacts.AddAsync(entity);
        }

        public IEnumerable<MemberContact> Get(Expression<Func<MemberContact, bool>> expression) {
            return _tableContext.MemberContacts.Where(expression);
        }

        public async Task<MemberContact> Find(string id) {
            return await _tableContext.MemberContacts.FindAsync(id);
        }

        public IEnumerable<MemberContact> GetAll() {
            return _tableContext.MemberContacts.ToList();
        }

        public async Task SaveChanges() {
            await _tableContext.SaveChangesAsync();
        }

        public async Task Update(MemberContact entity) {
            var memberContacts = _tableContext.MemberContacts.Where(s => s.MemberId == entity.MemberId);

            foreach(var memberContact in memberContacts) memberContact.IsDeleted = true;

            entity.CreateDate = DateTime.Now;
            await _tableContext.MemberContacts.AddAsync(entity);
        }
    }
}
