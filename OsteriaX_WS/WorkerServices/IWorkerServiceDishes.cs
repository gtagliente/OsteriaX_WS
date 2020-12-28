using System.Collections.Generic;
using modisAPI.Models;

namespace modisAPI.WorkerServices
{
    public interface IWorkerServiceDishes
    {
        //List<Dish> GetDishes(string type);
        Dish GetDish(int id);
        IEnumerable<Dish> GetDishByType(string type);
        void CreateDish(Dish dish);
        void UpdateDish(Dish updatedDish);
        void DeleteDish(int id);
    }
}