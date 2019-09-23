namespace papuff.backoffice.Models.Response {
    public class ReceiptResponse {
        public string Id { get; set; }
        public string WalletId { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public int DateDue { get; set; }
        public PaymentType Type { get; set; }
    }
}
