using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;

namespace DirectoryApp.DataAccessLayer.Repositories {
    public class MemberContactRepository : IRepository<MemberContact> {

        private readonly TableContext _tableContext;

        public MemberContactRepository(TableContext tableContext) {
            _tableContext = tableContext;
        }

        public void Create(MemberContact entity) {
            _tableContext.MemberContacts.Add(entity);
        }

        public IEnumerable<MemberContact> GetAll() {
            throw new NotImplementedException();
        }

        public void SaveChanges() {
            _tableContext.SaveChanges();
        }

        public void Update(MemberContact entity) {
            throw new NotImplementedException();
        }
    }
}
