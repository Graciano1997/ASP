using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace HelloAsp.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<IndexModel> _logger;

public IndexModel(IWebHostEnvironment environment, ILogger<IndexModel> logger)
        {
            _environment = environment;
            _logger = logger;
        }

     public string[] UserContacts { get; private set; }

    public void OnGet()
    {
        var dataFilePath = Path.Combine(_environment.WebRootPath, "App_Data", "ContactsBase.txt");
        // Read the file
        if (System.IO.File.Exists(dataFilePath))
        {
            UserContacts = System.IO.File.ReadAllLines(dataFilePath);

        } else
        {
        _logger.LogWarning($"File not found: {dataFilePath}");
        }

    }

    public void OnPost(){
        _logger.LogInformation("The Contact name is {ContactName}",owner);
        // Console.WriteLine($"The Contact name is {ContactName}");
    }
}
