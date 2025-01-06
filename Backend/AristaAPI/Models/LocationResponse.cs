using System.Collections.Generic;
using Newtonsoft.Json;

namespace AristaAPI.Models
{
    public class LocationResponse
    {
        [JsonProperty("places")]
        public List<Place> Places { get; set; }

        public double Latitud => double.TryParse(Places?.FirstOrDefault()?.Latitude, out var lat) ? lat : 0;
        public double Longitud => double.TryParse(Places?.FirstOrDefault()?.Longitude, out var lon) ? lon : 0;
    }
}
