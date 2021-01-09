using modisAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.StaticFiles;

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

        public MemoryStream GetItemImgStream(int id)
        {
            var filePath = db.Dishes.Where(x => x.Id == id).FirstOrDefault().ImgPath;

            return GetMemoryStream(filePath);
        }

        private static MemoryStream GetMemoryStream(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new FileNotFoundException();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            return memory;
        }

        public string GetItemContentType(int id)
        {
            string path  = db.Dishes.Where(x => x.Id == id).FirstOrDefault().ImgPath;

            return GetContentType(path);
        }

        private static string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public string GetItemFileName(int id)
        {
            string path = db.Dishes.Where(x => x.Id == id).FirstOrDefault().ImgPath;

            return Path.GetFileName(path);
        }
    }
}