namespace AristaAPI.Models
{
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
        public double? Latitud { get; set; } // Se asigna después de obtener los datos de la API externa
        public double? Longitud { get; set; } // Se asigna después de obtener los datos de la API externa
    }
}
