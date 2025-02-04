using AspNetFrameworkV4._8.DataAccess.Repositories;
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
        private readonly IClienteRepository _clienteRepository;
        private readonly ITipoClienteRepository _tipoClienteRepository;

        public ClientesController(IClienteRepository clienteRepository, ITipoClienteRepository tipoClienteRepository)
        {
            _clienteRepository = clienteRepository;
            _tipoClienteRepository = tipoClienteRepository;
        }

        public ActionResult Index()
        {
            var clientes = _clienteRepository.GetAllClientes();
            var tiposCliente = _tipoClienteRepository.GetAllTiposCliente().ToDictionary(tc => tc.Id, tc => tc.TipoCliente);

            var clienteViewModels = clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                RazonSocial = c.RazonSocial,
                IdTipoCliente = c.IdTipoCliente,
                NombreTipoCliente = tiposCliente.ContainsKey(c.IdTipoCliente) ? tiposCliente[c.IdTipoCliente] : "N/A",
                FechaCreacion = c.FechaCreacion,
                RFC = c.RFC
            }).ToList();

            return View(clienteViewModels);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IdTipoCliente = new SelectList(_tipoClienteRepository.GetAllTiposCliente(), "Id", "TipoCliente");
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RazonSocial,IdTipoCliente,FechaCreacion,RFC")] TblClientes cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.AddCliente(cliente);
                return RedirectToAction("Index");
            }

            ViewBag.IdTipoCliente = new SelectList(_tipoClienteRepository.GetAllTiposCliente(), "Id", "TipoCliente", cliente.IdTipoCliente);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipoCliente = new SelectList(_tipoClienteRepository.GetAllTiposCliente(), "Id", "TipoCliente", cliente.IdTipoCliente);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RazonSocial,IdTipoCliente,FechaCreacion,RFC")] TblClientes cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            ViewBag.IdTipoCliente = new SelectList(_tipoClienteRepository.GetAllTiposCliente(), "Id", "TipoCliente", cliente.IdTipoCliente);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteRepository.GetClienteById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _clienteRepository.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
