namespace papuff.backoffice.Models.Response {
    public class AuthResponse {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public UserType Type { get; set; }
    }
}
