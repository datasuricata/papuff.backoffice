using papuff.backoffice.Services.Notifications;

namespace papuff.backoffice.Models.Request {
    public class GuideRequest {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public EntryType Type { get; set; }

        // receipt
        public string Agency { get; set; }
        public string Account { get; set; }
        public string CPF { get; set; }
        public int DateDue { get; set; }
    }
}