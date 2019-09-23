using System.Collections.Generic;

namespace papuff.backoffice.Models.Response {
    public class WalletResponse {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ReceiptResponse Receipt { get; set; }
        public List<PaymentResponse> Payments = new List<PaymentResponse>();
    }
}