using System.ComponentModel.DataAnnotations;

namespace DirectoryApp.Models.DatabaseModels {
    public class Member {
        
        [Key]
        public string UUID { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }

    }
}
