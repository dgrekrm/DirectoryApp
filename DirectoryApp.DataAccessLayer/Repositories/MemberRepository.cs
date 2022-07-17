using DirectoryApp.DataAccessLayer.BaseModels;
using DirectoryApp.Models;
using DirectoryApp.Models.DatabaseModels;

namespace DirectoryApp.DataAccessLayer.Repositories {
    public class MemberRepository : IRepository<Member> {

        private readonly TableContext _tableContext;

        public MemberRepository(TableContext tableContext) {
            _tableContext = tableContext;
        }

        public void Create(Member entity) {
            _tableContext.Members.Add(entity);
        }

        public IEnumerable<Member> GetAll() {
            throw new NotImplementedException();
        }

        public void SaveChanges() {
            _tableContext.SaveChanges();
        }

        public void Update(Member entity) {
            throw new NotImplementedException();
        }
    }
}
