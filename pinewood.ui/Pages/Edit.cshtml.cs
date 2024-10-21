using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pinewood.shared.Dtos;
using pinewood.ui.services;

namespace pinewood.ui.Pages
{
    public partial class Edit : PageModel
	{
        private readonly ICustomerDataService _customerDataService;

        public Edit(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        [BindProperty]
        public CustomerDTO Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _customerDataService.GetCustomer(id);

            if (Customer == null)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromForm]CustomerDTO customer)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _customerDataService.UpdateCustomer(customer);

            return RedirectToPage("/Index");
        }
    }
}
