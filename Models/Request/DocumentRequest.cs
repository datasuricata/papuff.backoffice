using papuff.backoffice.Models.Response;

namespace papuff.backoffice.Models.Request {
    public class DocumentRequest {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public DocumentType Type { get; set; }

        public static explicit operator DocumentRequest(DocumentResponse v) {
            return v == null ? null : new DocumentRequest {
                Id = v.Id, ImageUri = v.ImageUri,
                Type = v.Type, Value = v.Value,
            };
        }
    }
}