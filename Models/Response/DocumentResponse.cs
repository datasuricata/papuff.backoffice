namespace papuff.backoffice.Models.Response {
    public class DocumentResponse {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public bool Aproved { get; set; }
        public DocumentType Type { get; set; }
        public string UserId { get; set; }
    }
}
