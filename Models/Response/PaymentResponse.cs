using System;

namespace papuff.backoffice.Models.Response {
    public class PaymentResponse {
        public string Id { get; set; }
        public string WalletId { get; set; }
        public string Card { get; set; }
        public DateTime Expiration { get; set; }
        public int Code { get; set; }
        public int DateDue { get; set; }
        public string Document { get; set; }
        public bool IsDefault { get; set; }
    }
}
