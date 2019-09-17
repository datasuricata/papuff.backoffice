using papuff.backoffice.Models.Response;

namespace papuff.backoffice.Models.Request {
    public class WalletRequest {
        public string Id { get; set; }
        public PaymentType Type { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public string Document { get; set; }
        public int DateDue { get; set; }
        public bool IsDefault { get; set; }

        public static explicit operator WalletRequest(WalletResponse v) {
            return v == null ? null : new WalletRequest {
                Id = v.Id, Account = v.Account, Agency = v.Agency,
                DateDue = v.DateDue, Document = v.Document,
                IsDefault = v.IsDefault, Type = v.Type,
            };
        }
    }
}