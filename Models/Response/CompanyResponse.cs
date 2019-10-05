using System;

namespace papuff.backoffice.Models.Response {
    public class CompanyResponse {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SiteUri { get; set; }
        public string CNPJ { get; set; }
        public string Tell { get; set; }
        public string Registration { get; set; }
        public DateTime OpeningDate { get; set; }
        public string UserId { get; set; }
        public AddressResponse Address { get; set; }
    }
}