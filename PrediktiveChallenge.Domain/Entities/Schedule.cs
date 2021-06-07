using Newtonsoft.Json;
using System.Collections.Generic;

namespace PrediktiveChallenge.Domain
{
    public class Schedule
    {
        [JsonProperty(PropertyName = "years")]
        public Dictionary<string, YearItem> YearItems { get; set; }
        public float DefaultMarketRatio { get; set; }
        public float DefaultAuctionRatio { get; set; }
    }
}
