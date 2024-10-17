using System;
using pinewood.shared.Dtos;

namespace pinewood.ui.services
{
	public interface ICustomerDataService
	{
		Task<IEnumerable<CustomerDTO>> GetCustomers();
	}
}

