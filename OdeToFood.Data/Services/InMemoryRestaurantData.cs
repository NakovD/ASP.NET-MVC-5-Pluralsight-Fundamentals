using OdeToFood.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Sam doidoh", Cuisine = CuisineType.Bulgarian },
                new Restaurant { Id = 2, Name = "Divaka", Cuisine = CuisineType.Other},
                new Restaurant { Id = 3, Name ="Dvata luva", Cuisine = CuisineType.Chinese },
            };
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void ChangeRestaurantData(Restaurant restaurant)
        {
            var neededRestaurant = GetRestaurantById(restaurant.Id);
            if (neededRestaurant != null)
            {
                neededRestaurant.Name = restaurant.Name;
                neededRestaurant.Cuisine = restaurant.Cuisine;
            }
        }

        public bool DeleteRestaurant(int id)
        {
            var restaurantToDelete = GetRestaurantById(id);
            if (restaurantToDelete != null)
            {
                return restaurants.Remove(restaurantToDelete);
            }
            return false;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.FirstOrDefault(restaurant => restaurant.Id == id);
        }
    }
}
