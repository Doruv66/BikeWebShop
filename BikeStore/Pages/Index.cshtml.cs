using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BikeClassLibrary;

namespace BikeStore.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public static Inventory inventory;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        inventory = new Inventory();
        inventory.MockBikes();
    }
}

