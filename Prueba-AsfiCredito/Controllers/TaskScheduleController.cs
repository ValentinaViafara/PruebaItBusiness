using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prueba_AsfiCredito.Database;

namespace Prueba_AsfiCredito.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskScheduleController : Controller
    {
        private IClientCollection db = new ClientCollection();
        private IAreaCollection area_db = new AreaCollection();
        private IActivityCollection activity_db = new ActivityCollection();
        private IDateTaskCollection date_db = new DateTaskCollection();
        private ITaskScheduleCollection task_db = new TaskScheduleCollection();

        [HttpGet]
        public async Task<IActionResult> getAllTask()
        {
            Console.WriteLine("Get All Tasks");
            return Ok(await task_db.getAllTasks());
            // return Ok(await db.getAllClientes());
        }

        [HttpGet("area")]
        public async Task<IActionResult> getAllAreas()
        {
            return Ok(await area_db.getAllAreas());
            // return Ok(await db.getAllClientes());
        }

        [HttpGet("activities")]
        public async Task<IActionResult> getAllActivity()
        {
            
            return Ok(await activity_db.getAllActivities());
            // return Ok(await db.getAllClientes());
        }

        [HttpGet("{Email}/{Password}")]
        public async Task<IActionResult> getClienteByEmailAndPassword(string email, string password)
        {
            await date_db.InsertDateTaskTemporal();
            return Ok(await db.getClienteByEmailAndPassword(email, password));
        }

        [HttpGet("{Email}")]
        public async Task<IActionResult> getClienteByEmail(string email)
        {
            return Ok(await db.getClienteByEmail(email));
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] TaskSchedule body)
        {
            // if(body== null)
            // {
            //     return BadRequest();
            // }

            // if(body.dateTask == null)
            // {
            //     return BadRequest();
            // }
            // if(body.task.IdClient == string.Empty)
            // {
            //     ModelState.AddModelError("Cliente", "El cliente no debe estar vacio");
            // }
            // if(body.task.IdArea == string.Empty)
            // {
            //     ModelState.AddModelError("Area", "El area no debe estar vacio");
            // }
            // if(body.task.IdActivity == string.Empty)
            // {
            //     ModelState.AddModelError("Actividad", "La actividad no debe estar vacio");
            // }

            
            Console.WriteLine("asd");
            Console.WriteLine("asd");
            // Console.WriteLine(body.IdDateTask);
            // Console.WriteLine(await date_db.getByString());
            Console.WriteLine("asd");
            Console.WriteLine("asd");

            return Created("Cliente Creado", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient([FromBody] Client client, string id)
        {
            if (client == null)
            {
                return BadRequest();
            }
            if (client.UserName == string.Empty)
            {
                ModelState.AddModelError("Nombre", "El nombre del cliente no debe estar vacio");
            }
            if (client.Email == string.Empty)
            {
                ModelState.AddModelError("Email", "El email del cliente no debe estar vacio");
            }
            if (client.Password == string.Empty)
            {
                ModelState.AddModelError("Password", "La contraseña del cliente no debe estar vacia");
            }
            client.Id = id;
            await db.UpdateClient(client);
            return Created("Cliente Actualizado", true);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            await db.DeleteClient(id);
            return NoContent();
        }

    }
}
