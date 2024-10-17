using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<CustomerDTO>> GetCustomers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<CustomerDTO>>(
                    await _httpClient.GetStreamAsync($"customers")
                //,
                //    new JsonSerializerOptions()
                //    {
                //        PropertyNameCaseInsensitive = true,
                //    }
                );
        }
    }
}

