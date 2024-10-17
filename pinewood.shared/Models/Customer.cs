using System;
using System.ComponentModel.DataAnnotations;

namespace pinewood.shared.Models
{
	public class Customer
	{
		public int Id { get; set; }
		[Required]
		public string? Name { get; set; } = default;
		[Required]
		[DataType(DataType.EmailAddress)]
		public string? EmailAddress { get; set; } = default;
		public string? TelephoneNumber { get; set; } = string.Empty;
		public string? PostalAddress { get; set; } = string.Empty;
		public string? PostalCode { get; set; } = string.Empty;
	}
}

