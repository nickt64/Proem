using Microsoft.AspNetCore.Mvc;
using SeguridadAspMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SeguridadAspMvc.Models;

namespace SeguridadAspMvc.Controllers
{
    public class ClientesController : Controller
    {

        private readonly ApplicationDbContext myDbContext;
        public ClientesController(ApplicationDbContext _myDbContext)
        {
            myDbContext = _myDbContext;
        }


        public IActionResult Index(string id, string nombre, string direccion, string telefono, string Cuit)
        {
            if (!string.IsNullOrEmpty(id))
            {
                int Id = 0;
                if (int.TryParse(id, out Id))
                {
                    myDbContext.Clientes.Add(new Cliente
                    {
                        ClienteId = Id,
                        Nombre = nombre,
                        Direccion = direccion,
                        Telefono = telefono,
                        Cuit = Cuit
                    });
                    myDbContext.SaveChanges();
                }

            }

            return View();
        }


        [HttpGet]
        public IActionResult Listado(string valor)
        {
            var model = new ClientesListadoModel();
            var query = myDbContext.Clientes.AsQueryable();

            if (!string.IsNullOrEmpty(valor))
            {
            query = query.Where(x => x.Nombre.Contains(valor));

            }
            model.Listado = query.ToList();
            return View(model);
        }

       //http GET Create
       public IActionResult Create()
        {
            return View();
        }

        //http POST Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                //if (!long.TryParse(cliente.Cuit, out long cuit))
                //{
                //    ModelState.AddModelError("Cuit", "El cuit deben ser solo numeros");
                //    return View(cliente);
                //}

                //if (cuit < 1000000000 || cuit > 9999999999)
                //{
                //    ModelState.AddModelError("Cuit", "El cuit deben ser 10 digitos");
                //    return View(cliente);
                //}

                var newCliente = new Cliente
                {
                    Nombre = cliente.Nombre,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    Cuit = cliente.Cuit,
                    CreadoPor = User.Identity.Name,
                    FechaCreacion = DateTime.Now,
                    ModificadoPor = User.Identity.Name,
                    FechaModificacion = DateTime.Now
                };
                
                myDbContext.Clientes.Add(newCliente);

                myDbContext.SaveChanges();

                TempData["mensaje"] = "El Cliente se ha agregado correctamente";

                return RedirectToAction("Listado");
            }

            return View(cliente);
        }

        //------------------------------------HTTP GET editar
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //var cliente = myDbContext.Clientes.Select(x => new {  x.ClienteId ,
            //                                                    x.Cuit,
            //                                                    x.Direccion,
            //                                                    x.Nombre,
            //                                                    x.FechaModificacion,
            //                                                    x.UsuarioModificacion,
            //                                                    x.Telefono})
            //                                                    .Where(x=> x.ClienteId == id);
            //obtener el cliente 
            var cliente = myDbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        //-----------------------------------HTTP POST editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDb = myDbContext.Clientes.Find(cliente.ClienteId);

                clienteDb.Nombre = cliente.Nombre;
                clienteDb.Telefono = cliente.Telefono;
                clienteDb.Direccion = cliente.Direccion;
                clienteDb.Cuit = cliente.Cuit;

                clienteDb.ModificadoPor = User.Identity.Name;
                clienteDb.FechaModificacion = DateTime.Now;

                myDbContext.Clientes.Update(clienteDb);
                myDbContext.SaveChanges();

                TempData["mensaje"] = "El cliente se ha actualizado correctamente";
                return RedirectToAction("Listado");
            }
            return View(); 
        }

        //------------------------------HTTP GET eliminar
        public IActionResult Delete(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }
            int ClienteId = (int)id;
            var cliente = myDbContext.Clientes.Find(ClienteId);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        //--------------------------------HTTP POST eliminar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCliente(int? ClienteId)
        {
            
            //obtener el cliente por id 
            var cliente = myDbContext.Clientes.Find(ClienteId);

            if(cliente == null)
            {
                return NotFound();
            }

                myDbContext.Clientes.Remove(cliente);
                myDbContext.SaveChanges();

                TempData["mensaje"] = "El cliente se ha eliminado correctamente";
                return RedirectToAction("Listado");
            
        }

        public IActionResult Editar(Cliente modelo)
        {
            if (modelo.ClienteId == 0)
            {
                myDbContext.Clientes.Add(modelo);
                
            }
            else
            {
                myDbContext.Attach(modelo);
                myDbContext.Entry(modelo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            
            myDbContext.SaveChanges();
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Editar(string id)
        {
            Cliente model;

            int Id = 0; 
            int.TryParse(id, out Id);
            if (Id == 0)
            {
                model = new Cliente();   //tambien podria ser ** model = new() **
            }
            else
            {
                model = myDbContext.Clientes.Find(Id);
            }
           
            return View(model);
        }

       

        
       
        
    }
}
