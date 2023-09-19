using System.Data;

namespace WebApplicationACFtechnologies.Models
{
    public class Cliente
    {
        public string identificacion { get; set; }
        public string primerNombre { get; set; }
        public string primerApellido { get; set;}   
        public int edad { get; set; }
        public string fechaDeCreacion { get; set; }

    }
}
