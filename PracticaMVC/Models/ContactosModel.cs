using System.ComponentModel.DataAnnotations;

namespace PracticaMVC.Models
{
    public class ContactosModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string? Direccion {  get; set; }
    }
}
