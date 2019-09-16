namespace papuff.backoffice.Models.Request {
    public class DocumentRequest {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public DocumentType Type { get; set; }
    }
}
