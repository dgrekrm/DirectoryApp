using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoryApp.Models.DatabaseModels {
    public class MemberContact {
        [Key]
        public string UUID { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }

        public string MemberId { get; set; }

        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; }
    }
}
