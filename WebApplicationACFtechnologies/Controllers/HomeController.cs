using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationACFtechnologies.Models;
using WebApplicationACFtechnologies.Repositorios.Contrato;

namespace WebApplicationACFtechnologies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Cliente> _clienteRepository;

        public HomeController(ILogger<HomeController> logger,
            IGenericRepository<Cliente> clienteRepository)


        {
            _logger = logger;
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> listaClientes()
        {
            List<Cliente> _lista = await _clienteRepository.Lista();
            
            return StatusCode(StatusCodes.Status200OK,_lista);
        }
        [HttpPost]
        public async Task<IActionResult> guardarCliente([FromBody] Cliente modelo)
        {
            bool _resultado = await _clienteRepository.Guardar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });

        }
        [HttpPut]
        public async Task<IActionResult> editarCliente([FromBody] Cliente modelo)
        {
            bool _resultado = await _clienteRepository.Editar(modelo);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
        }

        [HttpDelete]
        public async Task<IActionResult> eliminarCliente(int identificacion)
        {
            bool _resultado = await _clienteRepository.Eliminar(identificacion);

            if (_resultado)
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            else
                return StatusCode(StatusCodes.Status500InternalServerError, new { valor = _resultado, msg = "error" });
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}