using papuff.backoffice.Models.Helpers;
using papuff.backoffice.Models.Response;

namespace papuff.backoffice.Models.Request {
    public class UserRequest {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string Nick { get; set; }

        public static explicit operator UserRequest(UserResponse v) {
            return v == null ? null : new UserRequest {
                Email = v.Email,
                Id = v.Id,
                Nick = v.Nick,
                Password = v.Password.Encrypt(),
            };
        }
    }
}
