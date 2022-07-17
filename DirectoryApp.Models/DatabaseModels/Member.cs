using System.ComponentModel.DataAnnotations;

namespace DirectoryApp.Models.DatabaseModels {
    public class Member {

        public Member() {
            UUID = Guid.NewGuid().ToString();
        }

        [Key]
        public string UUID { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public bool IsDeleted { get; set; }

    }
}
