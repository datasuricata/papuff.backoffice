using System;
using papuff.backoffice.Models.Response;

namespace papuff.backoffice.Models.Request {
    public class ReceiptRequest {
        public string WalletId { get; set; }
        public string Agency { get; set; }
        public string Account { get; set; }
        public int DateDue { get; set; }

        public static explicit operator ReceiptRequest(ReceiptResponse v) {
            return v == null ? null : new ReceiptRequest {
                WalletId = v.WalletId, Account = v.Account,
                Agency = v.Agency, DateDue = v.DateDue,
            };
        }
    }
}