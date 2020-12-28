using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using modisAPI.Models;
using modisAPI.WorkerServices;

namespace ModisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesByTypeController : ControllerBase
    {
        private IWorkerServiceDishes worker;

        public DishesByTypeController(IWorkerServiceDishes _worker)
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
        [HttpGet("{type}", Name = "GetDishes")]
        public IEnumerable<Dish> GetDishes(string type)
        {
            return worker.GetDishByType(type);
        }

    }


}
