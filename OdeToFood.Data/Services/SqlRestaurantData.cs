using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDBContext db;
        public SqlRestaurantData(OdeToFoodDBContext db)
        {
            this.db = db;
        }
        public void AddRestaurant(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public void ChangeRestaurantData(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurantToDelete = GetRestaurantById(id);
            if (restaurantToDelete != null)
            {
                db.Restaurants.Remove(restaurantToDelete);
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }
    }
}
