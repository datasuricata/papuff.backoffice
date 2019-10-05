using System;

namespace papuff.backoffice.Models.Request {
    public class PaymentRequest {
        public DateTime Expiration { get; set; }
        public PaymentType Type { get; set; }
        public int Code { get; set; }
        public int DateDue { get; set; }
        public string WalletId { get; set; }
        public string Card { get; set; }
        public string Document { get; set; }
    }
}