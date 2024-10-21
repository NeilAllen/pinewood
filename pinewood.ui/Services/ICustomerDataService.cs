using System;
using pinewood.shared.Dtos;

namespace pinewood.ui.services
{
	public interface ICustomerDataService
	{
		Task<IEnumerable<CustomerDTO>> GetCustomers();
		Task<CustomerDTO> GetCustomer(int customerId);
        Task<CustomerDTO> CreateCustomer(CustomerDTO customer);
		Task UpdateCustomer(CustomerDTO customer);
		Task DeleteCustomer(int customerId);
    }
}

