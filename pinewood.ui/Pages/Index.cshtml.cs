using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pinewood.shared.Dtos;
using pinewood.ui.services;

namespace pinewood.ui.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ICustomerDataService _customerDataService;

    public List<CustomerDTO>? Customers { get; set; } = default;

    public IndexModel(ILogger<IndexModel> logger, ICustomerDataService customerDataService)
    {
        _logger = logger;
        _customerDataService = customerDataService;
    }

    public async Task OnGetAsync()
    {
        Customers = (await _customerDataService.GetCustomers())
            .ToList();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int Id)
    {
        await _customerDataService.DeleteCustomer(Id);

        return RedirectToPage();
    }
}

