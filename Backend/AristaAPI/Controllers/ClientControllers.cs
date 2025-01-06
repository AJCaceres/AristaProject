using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
// using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

using Dapper;

namespace AristaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(IConfiguration configuration, IHttpClientFactory httpClientFactory, ILogger<ClienteController> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        [HttpPost("mi-info")]
        public async Task<IActionResult> PostCliente([FromBody] ClienteRequest cliente)
        {
            if (cliente == null || string.IsNullOrWhiteSpace(cliente.CodigoPostal))
                return BadRequest("Datos del cliente no válidos");

            try
            {
                // Llama a Zippopotam.us
                var locationData = await GetLocationData(cliente.CodigoPostal);
                if (locationData == null)
                    return BadRequest("No se pudo obtener la ubicación.");

                // Agrega Latitud y Longitud al objeto cliente
                cliente.Latitud = locationData.Latitud;
                cliente.Longitud = locationData.Longitud;

                // Almacena en la base de datos
                await SaveToDatabase(cliente);

                return Ok(new 
                {
                    cliente
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        private async Task<LocationResponse?> GetLocationData(string codigoPostal)
        {
            // Usando _httpClientFactory para obtener un cliente HTTP
            _logger.LogInformation("EL URL QUE SE USA ES:  http://api.zippopotam.us/us/{CodigoPostal}", codigoPostal);
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://api.zippopotam.us/us/{codigoPostal}");
            if (!response.IsSuccessStatusCode)
                return null;

            var jsonResponse = await response.Content.ReadAsStringAsync();
            _logger.LogInformation("Respuesta de Zippopotam: {JsonResponse}", jsonResponse);
            var location = JsonConvert.DeserializeObject<LocationResponse>(jsonResponse);
            _logger.LogInformation("Locacion: {Location}", location);
            return location;
        }

        private async Task SaveToDatabase(ClienteRequest cliente)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = @"
                INSERT INTO Cliente (Nombre, Apellido, Correo, Telefono, Direccion, CodigoPostal, Pais, Mensaje, Latitud, Longitud)
                VALUES (@Nombre, @Apellido, @Correo, @Telefono, @Direccion, @CodigoPostal, @Pais, @Mensaje, @Latitud, @Longitud)";

            await connection.ExecuteAsync(query, cliente);
        }
    }

    public class ClienteRequest
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string? Pais { get; set; }
        public string? Mensaje { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
    }

    public class LocationResponse
    {
        [JsonProperty("places")]
        public List<Place> Places { get; set; }

        public double Latitud => double.TryParse(Places?.FirstOrDefault()?.Latitude, out var lat) ? lat : 0;
        public double Longitud => double.TryParse(Places?.FirstOrDefault()?.Longitude, out var lon) ? lon : 0;
    }

    public class Place
    {
        [JsonProperty("place name")]
        public string PlaceName { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("state abbreviation")]
        public string StateAbbreviation { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }
    }
}
