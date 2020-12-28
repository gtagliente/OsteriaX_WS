using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modisAPI.Models;
using modisAPI.WorkerServices;

namespace modisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private IWorkerServiceDishes worker;

        public DishController(IWorkerServiceDishes _worker)
        {
            worker = _worker;
        }

        // GET: api/Studenti
        //[HttpGet]
        //public IEnumerable<ViewModelStudente> Get()
        //{
        //    return worker.RestituisciListaStudenti();
        //}

        // GET: api/Studenti/5
        [HttpGet("{id}", Name = "Get")]
        public Dish Get(int id)
        {
            return worker.GetDish(id);
        }

        // POST: api/Studenti
        [HttpPost]
        public void Post(Dish dish)
        {
            worker.CreateDish(dish);
        }

        //// PUT: api/Studenti/5
       // [HttpPut("{id}")]
        [HttpPut]
        public void Put(Dish dish)
        {
            worker.UpdateDish(dish);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            worker.DeleteDish(id);
        }
    }
}
