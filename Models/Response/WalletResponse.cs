using System;

namespace papuff.backoffice.Models.Response {
    public class WalletResponse {
        public string Id { get; set; }
        public PaymentType Type { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public int DateDue { get; set; }
        public bool IsDefault { get; set; }

        public string Document { get; set; }
        public string Card { get; set; }
        public DateTime Expiration { get; set; }
        public int Code { get; set; }
        public string UserId { get; set; }
    }
}
