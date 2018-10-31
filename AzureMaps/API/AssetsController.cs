using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureMaps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Spatial;
using Newtonsoft.Json;

namespace AzureMaps.API
{
    [Route("api/[controller]")]
    public class AssetsController : Controller
    {
        public AssetsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        public IEnumerable<GeographyPoint> PinLocations { get; set; }

        [HttpGet]
        public IEnumerable<GeographyPoint> Get()
        {
            var assets = GetAssets();
            return assets;
        }

        private SearchIndexClient CreateSearchIndexClient()
        {
            string searchServiceName = Configuration["SearchServiceName"];
            string queryApiKey = Configuration["SearchServiceQueryApiKey"];

            SearchIndexClient indexClient = new SearchIndexClient(searchServiceName, "machineassets-index", new SearchCredentials(queryApiKey));
            return indexClient;
        }

        private IEnumerable<GeographyPoint> GetAssets()
        {
            var indexClient = CreateSearchIndexClient();
            var searchParameters = new SearchParameters()
            {
                Filter = "search.in(cid, 'qq0tt80vx657601de23jk41o89849t')",
                Select = new[] { "geolocation"}
            };            

            var searchResults = indexClient.Documents.Search<Asset>("*", searchParameters);                      
            var points = new List<GeographyPoint>();

            foreach (SearchResult<Asset> result in searchResults.Results)
            {
                points.Add(result.Document.GeoLocation);
            }

            return points;
        }
    }
}
