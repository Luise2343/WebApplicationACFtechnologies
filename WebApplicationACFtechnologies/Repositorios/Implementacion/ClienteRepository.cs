using WebApplicationACFtechnologies.Models;
using WebApplicationACFtechnologies.Repositorios.Contrato;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace WebApplicationACFtechnologies.Repositorios.Implementacion
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        public readonly string _cadenaSQL = "";
        //private object _lista;

        public ClienteRepository(IConfiguration configuracion)
        {
            _cadenaSQL = configuracion.GetConnectionString("_cadenaSQL");
        }


        public async Task<List<Cliente>> Lista()
        {
            try
            {
                List<Cliente> lista = new List<Cliente>();
                using (var conexion = new SqlConnection(_cadenaSQL))
                {
                    await conexion.OpenAsync();
                    using (var cmd = new SqlCommand("ListarClientes", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (var dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                lista.Add(new Cliente
                                {
                                    identificacion = Convert.ToInt32(dr["identificacion"]),
                                    primerNombre = dr["primerNombre"].ToString(),
                                    primerApellido = dr["primerApellido"].ToString(),
                                    edad = Convert.ToInt32(dr["edad"]),
                                    fechaDeCreacion = dr["fechaDeCreacion"].ToString()
                                });
                            }
                        }
                    }
                }

                return lista; // Agregamos el retorno de la lista.
            }
            catch (Exception ex)
            {
                // Manejo de excepciones: Registra el error o realiza alguna acción específica para identificar el problema.
                Console.WriteLine($"Error en Lista(): {ex.Message}");
                throw; // Opcionalmente, puedes lanzar la excepción nuevamente.
            }
        }


        public async Task<bool> Guardar(Cliente Modelo)
        {
            using (var conexcion = new SqlConnection(_cadenaSQL))
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
            using (var conexcion = new SqlConnection(_cadenaSQL))
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
            using (var conexcion = new SqlConnection(_cadenaSQL))
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
