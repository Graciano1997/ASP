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
    
    [BindProperty]
    public string Owner { get; set; }

    [BindProperty]
    public string ContactNumber{get;set;}    
    public string Status{get;set;}

    public void OnGet()
    {
        Status="pending";
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
        // _logger.LogInformation($"The Contact name is {Owner} and the Number is {ContactNumber}");
        var dataFilePath = Path.Combine(_environment.WebRootPath, "App_Data", "ContactsBase.txt");
        // Read the file

        string contact=$"{Owner},{ContactNumber}";

        if (System.IO.File.Exists(dataFilePath))
        {
            System.IO.File.AppendAllText(dataFilePath,contact + Environment.NewLine);
            Status="ok";
        } else
        {
        Status="error";
        _logger.LogWarning($"File not found: {dataFilePath}");
        }
    }
}
