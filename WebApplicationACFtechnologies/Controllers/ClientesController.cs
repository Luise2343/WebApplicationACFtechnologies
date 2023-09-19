using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplicationACFtechnologies.Models;

namespace NombreDeTuProyecto.Controllers
{
    public class ClientesController : Controller
    {
        private readonly string _connectionString;

        public ClientesController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sqlQuery = "SELECT * FROM Clientes";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente = new Cliente
                            {
                                
                                identificacion = reader["Identification"].ToString(),
                                primerNombre = reader["PrimerNombre"].ToString(),
                                primerApellido = reader["PrimerApellido"].ToString(),
                                edad = Convert.ToInt32(reader["Edad"]),
                                fechaDeCreacion = Convert.ToDateTime(reader["FechaDeCreacion"])
                            };
                            clientes.Add(cliente);
                        }
                    }
                }
            }

            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sqlQuery = "INSERT INTO Clientes (Identification, PrimerNombre, PrimerApellido, Edad, FechaDeCreacion) VALUES (@Identification, @PrimerNombre, @PrimerApellido, @Edad, @FechaDeCreacion)";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Identification", cliente.Identification);
                        command.Parameters.AddWithValue("@PrimerNombre", cliente.PrimerNombre);
                        command.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                        command.Parameters.AddWithValue("@Edad", cliente.Edad);
                        command.Parameters.AddWithValue("@FechaDeCreacion", cliente.FechaDeCreacion);

                        command.ExecuteNonQuery();
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // Implementa métodos para Edit, Details y Delete aquí...

        // GET: Clientes/Edit/5
        public IActionResult Edit(int id)
        {
            // Implementa la lógica para obtener y mostrar un cliente para edición
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            // Implementa la lógica para actualizar un cliente en la base de datos
        }

        // GET: Clientes/Details/5
        public IActionResult Details(int id)
        {
            // Implementa la lógica para obtener y mostrar los detalles de un cliente
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int id)
        {
            // Implementa la lógica para obtener y mostrar la confirmación de eliminación de un cliente
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Implementa la lógica para eliminar un cliente de la base de datos
        }
    }
}
