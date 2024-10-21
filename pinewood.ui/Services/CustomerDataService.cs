using System.Text;
using System.Text.Json;
using pinewood.shared.Dtos;
using pinewood.ui.services;

namespace pinewood.ui.Services
{
    public class CustomerDataService : ICustomerDataService
	{
        private readonly HttpClient _httpClient = default;

		public CustomerDataService(HttpClient httpClient)
		{
            _httpClient = httpClient;
		}

        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customer)
        {
            var json = new StringContent(JsonSerializer.Serialize(customer),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("customers", json);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<CustomerDTO>(
                    await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async Task DeleteCustomer(int customerId)
        {
            await _httpClient.DeleteAsync($"customers/{customerId}");
        }

        public async Task<CustomerDTO> GetCustomer(int customerId)
        {
            var json = await _httpClient.GetStreamAsync($"customers/{customerId}");
            var customer = await JsonSerializer.DeserializeAsync<CustomerDTO>(
                    json,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    }
                );

            return customer;
        }        

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            var json = await _httpClient.GetStreamAsync($"customers");
            var customerList = await JsonSerializer.DeserializeAsync<IEnumerable<CustomerDTO>>(
                    json,
                    new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    }
                );

            return customerList;
        }

        public async Task UpdateCustomer(CustomerDTO customer)
        {
            var json = new StringContent(JsonSerializer.Serialize(customer),
                Encoding.UTF8,
                "application/json");

            await _httpClient.PutAsync($"customers/{customer.Id}", json);
        }
    }
}

