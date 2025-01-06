
using System.ComponentModel.DataAnnotations;


namespace FrontendArista.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
        public string Correo { get; set; }
        public string Telefono { get; set; }
        [MaxLength(255, ErrorMessage = "La dirección no puede tener más de 255 caracteres.")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El código postal es obligatorio.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El código postal solo puede contener números.")]
        [MaxLength(6, ErrorMessage = "El código postal no puede tener más de 6 caracteres.")]
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
        [MaxLength(500, ErrorMessage = "El mensaje no puede tener más de 500 caracteres.")]
        public string Mensaje { get; set; }
    }
}