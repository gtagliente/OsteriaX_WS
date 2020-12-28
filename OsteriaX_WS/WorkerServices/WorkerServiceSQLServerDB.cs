using modisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace modisAPI.WorkerServices
{
    public class WorkerServiceSQLServerDB : IWorkerServiceDishes
    {
        private OsteriaContext db;

        public WorkerServiceSQLServerDB(OsteriaContext _db)
        {
            db = _db;
        }

        public Dish GetDish(int id)
        {
            return db.Dishes.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Dish> GetDishByType(string type)
        {
            return db.Dishes.Where(x => x.Tipo == type).ToList();
        }

        public void UpdateDish(Dish updatedDish)
        {
            db.Entry(updatedDish).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public void CreateDish(Dish dish)
        {
            db.Dishes.Add(dish);
            db.SaveChanges();
        }
        public void DeleteDish(int id)
        {
            db.Entry(GetDish(id)).State =
               Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();
        }
    }
}