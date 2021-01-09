using System.Collections.Generic;
using System.IO;
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
        MemoryStream GetItemImgStream(int id);
        string GetItemContentType(int path);

        string GetItemFileName(int id);
    }
}