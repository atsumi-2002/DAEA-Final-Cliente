using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DAEA_MVC_Final.Models;
using DAEA_MVC_Final.Services;

namespace DAEA_MVC_Final.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _ClienteService;
        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            List<Cliente> lista = await _ClienteService.Listar();
            return View(lista);
        }

        // GET: Cliente/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Cliente cliente = await _ClienteService.Obtener(id);
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                bool respuesta;

                respuesta = await _ClienteService.Guardar(cliente);

                if (respuesta)
                {
                    return RedirectToAction("Index");
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Cliente cliente = await _ClienteService.Obtener(id);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Cliente cliente)
        {
            try
            {
                bool respuesta;

                respuesta = await _ClienteService.Editar(cliente);

                if (respuesta)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                bool respuesta;

                respuesta = await _ClienteService.Eliminar(id);

                if (respuesta)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
