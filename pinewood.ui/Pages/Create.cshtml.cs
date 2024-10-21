using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pinewood.shared.Dtos;
using pinewood.ui.services;

namespace pinewood.ui.Pages
{
	public partial class Create : PageModel
    {
        private readonly ICustomerDataService _customerDataService;

        public Create(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the input data
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _customerDataService.CreateCustomer(Customer);

            return RedirectToPage("/Index");
        }
    }
}

