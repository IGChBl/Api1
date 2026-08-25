using Microsoft.AspNetCore.Mvc;

namespace Api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PruebaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string msn = "Hola mundo";
            return Ok(new
            {
                msn
            });
        }

        [HttpGet("presentacion")]
        public IActionResult Presentacion(
            string nombre,
            int edad,
            string direccion,
            string sexo,
            string universidad,
            string carrera)
        {
            string msn = $"Hola, me llamo {nombre}, tengo {edad} anios, vivo en {direccion}, " +
                         $"soy de sexo {sexo} y estudio {carrera} en la {universidad}.";

            return Ok(new
            {
                nombre,
                edad,
                direccion,
                sexo,
                universidad,
                carrera,
                msn
            });
        }

        [HttpGet("iva")]
        public IActionResult CalcIVA(
            [FromQuery] decimal precio
            )
        {
            decimal iva = precio * (decimal) 0.15;
            return Ok(
                new
                {
                    precio,
                    iva
                }
                );

        }

        [HttpGet("calificacion")]
        public IActionResult TipoCalificacion(
            [FromQuery] decimal nota
            )
        {
            if (nota < 0 || nota > 100)
            {
                return BadRequest(new { msn = "La nota debe estar entre 0 y 100." });
            }

            string calificacion;

            if (nota >= 90)
            {
                calificacion = "Excelente";
            }
            else if (nota >= 80)
            {
                calificacion = "Sobresaliente";
            }
            else if (nota >= 70)
            {
                calificacion = "Bueno";
            }
            else if (nota >= 60)
            {
                calificacion = "Regular";
            }
            else
            {
                calificacion = "Deficiente";
            }

            bool aprobado = nota >= 60;

            string msn = $"Con una nota de {nota} tu calificacion es: {calificacion}.";

            return Ok(
                new
                {
                    nota,
                    calificacion,
                    aprobado,
                    msn
                }
                );
        }
    }
}

/* http://localhost:5130/api/Prueba/presentacion?nombre=Ivan&edad=28&direccion=Managua&sexo=Masculino&universidad=UAM&carrera=IngenieriaenSistemas
 http://localhost:5130/api/Prueba/iva?precio=1000
 http://localhost:5130/api/Prueba/calificacion?nota=85 */