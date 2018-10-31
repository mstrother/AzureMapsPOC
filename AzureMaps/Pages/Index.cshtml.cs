using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMaps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AzureMaps.Pages
{
    public class IndexModel : PageModel
    {
        public string AzureMapsSubscriptionKey {get; private set;}

        public IndexModel(IConfiguration configuration)
        {
            AzureMapsSubscriptionKey = configuration["AzureMapsSubscriptionKey"];
        }

        public void OnGet()
        {
        }
    }
}
