using DirectoryApp.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace DirectoryApp.Models {
    public class TableContext : DbContext {
        public TableContext(DbContextOptions<TableContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberContact> MemberContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql();
        }
    }
}
