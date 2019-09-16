using System;

namespace papuff.backoffice.Models.Response {
    public class GeneralResponse {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public CurrentStage Stage { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserId { get; set; }
    }
}
