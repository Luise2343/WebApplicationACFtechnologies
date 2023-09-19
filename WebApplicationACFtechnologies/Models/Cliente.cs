using System;

namespace WebApplicationACFtechnologies.Models
{
    public class Cliente
    {
        public int identificacion { get; set; }
        public string primerNombre { get; set; }
        public string primerApellido { get; set; }
        public int edad { get; set; }
        public string fechaDeCreacion { get; set; }

        // Propiedad adicional para el nombre completo
        public string nombreCompleto
        {
            get
            {
                // Combina el primer nombre y el primer apellido con un espacio en blanco
                return $"{primerNombre} {primerApellido}";
            }
        }
    }
}
