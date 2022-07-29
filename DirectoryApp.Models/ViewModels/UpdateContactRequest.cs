namespace DirectoryApp.Models.ViewModels {
    public class UpdateContactRequest {
        public string MemberId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}
