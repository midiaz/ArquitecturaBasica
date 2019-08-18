using System;
using System.ComponentModel.DataAnnotations;

namespace Arquitectura.Negocio.Entidades
{
    public class Cliente
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Display(Name = "N° de Documento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es obligatorio.")]
        public string Documento { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Este campo es obligatorio.")]
        public string CorreoElectronico { get; set; }

        [Display(Name = "Fecha Desactivado")]
        public DateTime? FechaBaja { get; set; }

    }
}
