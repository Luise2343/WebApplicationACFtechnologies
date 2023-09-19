using WebApplicationACFtechnologies.Models;
using WebApplicationACFtechnologies.Repositorios.Contrato;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WebApplicationACFtechnologies.Repositorios.Implementacion
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        public readonly string _cadenaSQL_ = "";
        private object _lista;

        public ClienteRepository(IConfiguration configuracion)
        {
            _cadenaSQL_ = configuracion.GetConnectionString("_cadenaSQL_");
        }


        public async Task<List<Cliente>> Lista()
        {
            List<Cliente> lista = new List<Cliente>();
            using (var conexcion = new SqlConnection(_cadenaSQL_))
            {
                conexcion.Open();
                SqlCommand cmd = new SqlCommand("ListaClientes", conexcion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        lista.Add(new Cliente
                        {
                            identificacion = Convert.ToInt32(dr["identificacion"]),
                            primerNombre = dr["nombreCompleto"].ToString(),
                            edad = Convert.ToInt32(dr["edad"]),
                            fechaDeCreacion = dr["fechaDeCreacion"].ToString()
                        });
                    };
                }
            }
            return lista;

        }
        public async Task<bool> Guardar(Cliente Modelo)
        {
            using (var conexcion = new SqlConnection(_cadenaSQL_))
            {
                conexcion.Open();
                SqlCommand cmd = new SqlCommand("InsertarCliente", conexcion);
                cmd.Parameters.AddWithValue("@PrimerNombre", Modelo.primerNombre);
                cmd.Parameters.AddWithValue("@PrimerApellido", Modelo.primerApellido);
                cmd.Parameters.AddWithValue("@Edad", Modelo.edad);
                cmd.Parameters.AddWithValue("@FechaDeCreacion", Modelo.fechaDeCreacion);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();
                if (filas_afectadas > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<bool> Editar(Cliente Modelo)
        {
            using (var conexcion = new SqlConnection(_cadenaSQL_))
            {
                conexcion.Open();
                SqlCommand cmd = new SqlCommand("EditarCliente", conexcion);
                cmd.Parameters.AddWithValue("Identificacion", Modelo.identificacion);
                cmd.Parameters.AddWithValue("@NuevoPrimerNombre", Modelo.primerNombre);
                cmd.Parameters.AddWithValue("@NuevoPrimerApellido", Modelo.primerApellido);
                cmd.Parameters.AddWithValue("@NuevaEdad", Modelo.edad);
                cmd.Parameters.AddWithValue("@NuevaFechaDeCreacion", Modelo.fechaDeCreacion);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();
                if (filas_afectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> Eliminar(int identificacion)
        {
            using (var conexcion = new SqlConnection(_cadenaSQL_))
            {
                conexcion.Open();
                SqlCommand cmd = new SqlCommand("EliminarCliente", conexcion);
                cmd.Parameters.AddWithValue("Identificacion",identificacion);
                cmd.CommandType = CommandType.StoredProcedure;

                int filas_afectadas = await cmd.ExecuteNonQueryAsync();
                if (filas_afectadas > 0)
                    return true;
                else
                    return true;
            }
        }
    }
}
