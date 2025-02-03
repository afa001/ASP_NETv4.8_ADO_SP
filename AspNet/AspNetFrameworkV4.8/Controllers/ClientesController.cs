using AspNetFrameworkV4._8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkV4._8.Controllers
{
    public class ClientesController : Controller
    {
        private readonly WebServiceClientGlobal _apiClient = new WebServiceClientGlobal();

        public async Task<ActionResult> Index()
        {
            var clientes = await _apiClient.GetAllClientesAsync();

            foreach (var cliente in clientes)
            {
                if (cliente.TipoCliente == null)
                {
                    cliente.TipoCliente = await _apiClient.GetAllTiposClientesByIdAsync(cliente.IdTipoCliente);
                }
            }

            return View(clientes);
        }

        public async Task<ActionResult> Create()
        {
            var tiposCliente = await _apiClient.GetAllTiposClientesAsync();
            ViewBag.TiposClientes = new SelectList(tiposCliente, "Id", "TipoCliente");

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(TblClientes cliente)
        {
            if (ModelState.IsValid)
            {
                await _apiClient.AddClienteAsync(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _apiClient.GetClienteByIdAsync(id);
            var tiposCliente = await _apiClient.GetAllTiposClientesAsync();
            ViewBag.TiposClientes = new SelectList(tiposCliente, "Id", "TipoCliente");
            return View(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(TblClientes cliente)
        {
            if (ModelState.IsValid)
            {
                await _apiClient.UpdateClienteAsync(cliente.Id, cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _apiClient.GetClienteByIdAsync(id);
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await _apiClient.DeleteClienteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
