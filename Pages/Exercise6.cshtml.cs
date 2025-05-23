using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SpinutechAssessment.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private decimal number;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (Request.Form != null)
        {
            var input = Request.Form["integer-input"].ToString();
            string reverse = ""; string ret = $"{input} is not a palindrome";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                // Do something
                reverse += input.Substring(i, 1);
            }

            if (reverse.Equals(input)) ret = $"{input} is a palindrome";
            ViewData["ret"] = ret;
        }
    }
}

