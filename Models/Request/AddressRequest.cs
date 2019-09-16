using papuff.backoffice.Models.Response;

namespace papuff.backoffice.Models.Request {
    public class AddressRequest {
        public string Id { get; set; }
        public string CompanyId { get; set; }
        public BuildingType Building { get; set; }
        public int Number { get; set; }
        public int Complement { get; set; }
        public string AddressLine { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public static explicit operator AddressRequest(AddressResponse v) {
            return v == null ? null : new AddressRequest {
                Id = v.Id, AddressLine = v.AddressLine,
                Building = v.Building, City = v.City,
                CompanyId = v.CompanyId, Complement = v.Complement,
                Country = v.Country, District = v.District,
                Number = v.Number, PostalCode = v.PostalCode,
                StateProvince = v.StateProvince,
            };
        }
    }
}