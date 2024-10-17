using System;
using pinewood.api.Models;

namespace pinewood.shared.Dtos
{
	public class CustomerDTO
	{
        public int Id { get; set; }
        public string? Name { get; set; } = default;
        public string? EmailAddress { get; set; } = default;
        public string? TelephoneNumber { get; set; } = default;
        public string? PostalAddress { get; set; } = default;
        public string? PostalCode { get; set; } = default;

        public CustomerDTO() { }
        public CustomerDTO(Customer customer) => (Id, Name, EmailAddress, PostalAddress, PostalCode, TelephoneNumber) = (
            customer.Id,
            customer.Name,
            customer.EmailAddress,
            customer.PostalAddress,
            customer.PostalCode,
            customer.TelephoneNumber);
    }
}

