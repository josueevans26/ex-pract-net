using Microsoft.AspNetCore.Mvc;
using Ex1.Models;

public class EncuestasController : Controller
{
    private readonly AppDbContext _context;

    public EncuestasController(AppDbContext context)
    {
        _context = context;
    }

    // Mostrar todas las encuestas
    public IActionResult Index()
    {
        return View(_context.Encuestas.ToList());
    }

    // Mostrar formulario para agregar una nueva encuesta
    public IActionResult Create()
    {
        return View();
    }

    // Procesar la solicitud de agregar una nueva encuesta
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Encuestas encuestaRespuesta, string[] checkboxRespuestas51, string[] checkboxRespuestas52, string[] checkboxRespuestas7)
        {
            if (ModelState.IsValid)
            {
                // Convertir respuestas de checkbox a una cadena separada por comas

                if(checkboxRespuestas51 != null)
                {
                    string respuestasCheckbox51 = string.Join(";", checkboxRespuestas51);
                    encuestaRespuesta.Respuesta5_1 = respuestasCheckbox51;
                }

                if(checkboxRespuestas52 != null)
                {
                    string respuestasCheckbox52 = string.Join(";", checkboxRespuestas52);
                    encuestaRespuesta.Respuesta5_2 = respuestasCheckbox52;
                }

                if(checkboxRespuestas7 != null)
                {
                    string respuestasCheckbox7 = string.Join(";", checkboxRespuestas7);
                    encuestaRespuesta.Respuesta7 = respuestasCheckbox7;
                }

                _context.Encuestas.Add(encuestaRespuesta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(encuestaRespuesta);
        }
}