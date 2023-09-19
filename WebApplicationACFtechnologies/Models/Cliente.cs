using System.Data;

namespace WebApplicationACFtechnologies.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string PrimerNombre { get; set; }
        public string PrimerApellido { get; set;}   
        public int Edad { get; set; }
        public DateTime FechaDeCreacion { get; set; }

    }
}
