namespace DirectoryApp.Models.ViewModels {
    public class CreateMemberRequest {
        public string FullName { get; set; }
        public string Company { get; set; }

        #region Contact Information

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }

        #endregion
    }
}
