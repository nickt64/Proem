using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppProemMvc1.Models;

namespace WebAppProemMvc1.Controllers
{
    public class ClientesController : Controller
    {

        public  MyDbContext myDbContext { get; set; }

        public ClientesController(MyDbContext _myDbContext)
        {
            myDbContext = _myDbContext;
        }


        public IActionResult Index(string id, string nombre, string direccion, string telefono, int Cuit)
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
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                myDbContext.Clientes.Add(cliente);
                myDbContext.SaveChanges();

                TempData["mensaje"] = "El Cliente se ha agregado correctamente";

               
            }
            return RedirectToAction("Listado"); 
        }

        //------------------------------------HTTP GET editar
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //obtener el cliente 
            Cliente cliente = myDbContext.Clientes.Find(id);

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
                myDbContext.Clientes.Update(cliente);
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
