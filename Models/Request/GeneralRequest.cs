using System;
using papuff.backoffice.Models.Response;

namespace papuff.backoffice.Models.Request {
    public class GeneralRequest {
        public string Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static explicit operator GeneralRequest(GeneralResponse v) {
            return v == null ? null : new GeneralRequest {
                Id = v.Id,
                BirthDate = v.BirthDate,
                Description = v.Description,
                Name = v.Name,
            };
        }
    }
}
