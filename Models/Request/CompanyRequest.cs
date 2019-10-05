using System;

namespace papuff.backoffice.Models.Request {
    public class CompanyRequest {
        public string Name { get; set; }
        public string Email { get; set; }
        public string SiteUri { get; set; }
        public string CNPJ { get; set; }
        public string Tell { get; set; }
        public string Registration { get; set; }
        public DateTime OpeningDate { get; set; }
    }
}
