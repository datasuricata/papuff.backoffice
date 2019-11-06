using System;

namespace papuff.backoffice.Services.Notifications {
    public class Notification {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Date { get; set; }

        public Notification() {
            Id = Guid.NewGuid().ToString().ToUpper().Replace("-", "");
            Date = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            Value = "Ops! Algo deu errado.";
        }
    }
}