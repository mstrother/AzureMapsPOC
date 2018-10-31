using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureMaps.Models
{
    public class Asset
    {
        [JsonProperty("indexkey_serialnumber")]
        [System.ComponentModel.DataAnnotations.Key]
        public string IndexKey_SerialNumber { get; set; }

        [JsonProperty("serialnumber")]
        [IsSearchable]
        public string SerialNumber { get; set; }

        [JsonProperty("cid")]
        [IsFilterable]
        public string CID { get; set; }

        [JsonProperty("productfamily")]
        [IsSearchable, IsSortable, IsFacetable]
        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string ProductFamily { get; set; }

        [JsonProperty("productfamily_index")]
        [IsFilterable, IsRetrievable(false)]
        public string ProductFamily_Index { get; set; }

        [JsonProperty("geolocation")]
        [IsFilterable]
        public GeographyPoint GeoLocation { get; set; }

        [JsonProperty("make")]
        [IsSearchable, IsSortable, IsFacetable]
        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string Make { get; set; }

        [JsonProperty("make_index")]
        [IsFilterable, IsRetrievable(false)]
        public string Make_Index { get; set; }

        [JsonProperty("model")]
        [IsSearchable, IsSortable, IsFacetable]
        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string Model { get; set; }

        [JsonProperty("model_index")]
        [IsFilterable, IsRetrievable(false)]
        public string Model_Index { get; set; }

        [JsonProperty("serviceagreementstatus")]
        [IsSearchable, IsSortable]
        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string ServiceAgreementStatus { get; set; }

        [IsFilterable, IsRetrievable(false)]
        public string ServiceAgreementStatus_index { get; set; }

        [JsonProperty("warranty")]
        [IsSearchable, IsSortable, IsFacetable]
        [Analyzer(AnalyzerName.AsString.EnMicrosoft)]
        public string Warranty { get; set; }

        [JsonProperty("warranty_index")]
        [IsFilterable, IsRetrievable(false)]
        public string Warranty_index { get; set; }

        [JsonProperty("lastreporteddate")]
        [IsFilterable, IsSortable]
        public DateTime? LastReportedDate { get; set; }

        [JsonProperty("tags")]
        [IsFilterable, IsSortable, IsFacetable]
        public string Tags { get; set; }

        [JsonProperty("assetid")]
        [IsSearchable]
        public string AssetID { get; set; }

        [JsonProperty("status")]
        [IsFacetable]
        public string Status { get; set; }

        [JsonProperty("status_index")]
        [IsFilterable, IsRetrievable(false)]
        public string Status_index { get; set; }

        [JsonProperty("yearofmanufacture")]
        public int? YearOfManufacture { get; set; }

        [JsonProperty("lifetimehours")]
        public double? LifeTimeHours { get; set; }

        [JsonProperty("fuelremainingpercentage")]
        public double? FuelRemainingPercentage { get; set; }

        [JsonProperty("lifetimemileage")]
        public double? LifetimeMileage { get; set; }

        [JsonProperty("lifetimefuelconsumptiongallons")]
        public double? LifetimeFuelConsumptionGallons { get; set; }

        [JsonProperty("lastfuelreportedtime")]
        public DateTime? LastFuelReportedTime { get; set; }
    }
}
