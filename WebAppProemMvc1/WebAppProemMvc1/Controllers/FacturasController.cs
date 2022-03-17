using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProemMvc1.Models;

namespace WebAppProemMvc1.Controllers
{
    public class FacturasController : Controller
    {
        private readonly MyDbContext myDbContext;
        
        public FacturasController(MyDbContext _myDbContext)
        {
            myDbContext = _myDbContext;

           
        }

        public void ComboClientes()
        {
            var clientes = myDbContext.Clientes.ToList();

            SelectList item = new SelectList(clientes, "ClienteId", "Nombre");

            ViewBag.Clientes = item;
        }


        public IActionResult Index(string valor)
        {
            ViewBag.ListaFacturas = new FacturasListadoModels();
            var query = myDbContext.Facturas.Include(x => x.Cliente).AsQueryable();

            if (!string.IsNullOrEmpty(valor))
            {
                query = query.Where(x => x.Cliente.Nombre.Contains(valor));

            }
            ViewBag.ListaFacturas = query.ToList();
            //ViewBag.ListaFacturas = myDbContext.Facturas.Include(x=> x.Cliente).ToList();
            return View();

        }

        //---------------------------------GET crear factura--
        public IActionResult Create()
        {
            ComboClientes();

            return View();
        }

        //http POST Create
        [HttpPost]
        public IActionResult Create(Factura factura)
        {
            

            if (ModelState.IsValid)
            {
                myDbContext.Facturas.Add(factura);
                myDbContext.SaveChanges();

                TempData["mensaje"] = "la factura se ha agregado correctamente";


            }
            return RedirectToAction("Index");
        }

        //------------------------------------HTTP GET editar
        public IActionResult Edit(int? id)
        {
            ComboClientes();

            if (id == null || id == 0)
            {
                return NotFound();
            }
            int FacturaId = (int)id;
            //obtener el cliente 
            Factura factura = myDbContext.Facturas.Find(FacturaId);

            if ( factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        //-----------------------------------HTTP POST editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                myDbContext.Facturas.Update(factura);
                myDbContext.SaveChanges();

                TempData["mensaje"] = "La factura se ha actualizado correctamente";
            }


            return RedirectToAction("Index");

        }

        //------------------------------HTTP GET eliminar
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            int FacturaId = (int)id;

            var factura = myDbContext.Facturas.Find(FacturaId);

            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }


        //--------------------------------HTTP POST eliminar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteFactura(int? id)
        {
            //obtener el cliente por id 
            int FacturaId = (int)id;
            var factura = myDbContext.Facturas.Find(FacturaId);

            if (factura == null)
            {
                NotFound();
            }

            myDbContext.Facturas.Remove(factura);
            myDbContext.SaveChanges();

            TempData["mensaje"] = "La factura se ha eliminado correctamente";
            return RedirectToAction("Index");

        }
    }
}
