using System.Collections.Generic;
using AzureMaps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Spatial;

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
            var filter = $"search.in(cid, '{Configuration["CId"]}')";
            var searchParameters = new SearchParameters()
            {
                Filter = filter,
                Select = new[] { "geolocation"}
            };            

            var searchResults = indexClient.Documents.Search<AssetIndex>("*", searchParameters);                      
            var points = new List<GeographyPoint>();

            foreach (SearchResult<AssetIndex> result in searchResults.Results)
            {
                points.Add(result.Document.GeoLocation);
            }

            return points;
        }
    }
}
