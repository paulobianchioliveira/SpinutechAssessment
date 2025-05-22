using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Text;

namespace SpinutechAssessment.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private decimal number;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", true);
    }

    public void OnGet()
    {
    }
    public void OnPost()
    {
        if (Request.Form != null)
        {
            var input = Request.Form["currency"].ToString();
            decimal.TryParse(input, out number);

            string ret = Utils.NumberToWords(number);

            ViewData["ret"] = ret;
        }            
    }
}
