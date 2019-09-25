using System;

namespace papuff.backoffice.Models.Response {
    public class PaymentResponse {
        public string Id { get; set; }
        public string WalletId { get; set; }
        public string Card { get; set; }
        public string Document { get; set; }
        public PaymentType Type { get; set; }
        public bool IsDefault { get; set; }
    }
}
