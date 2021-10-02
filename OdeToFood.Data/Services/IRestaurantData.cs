using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetRestaurantById(int id);
        void AddRestaurant(Restaurant restaurant);
        void ChangeRestaurantData(Restaurant restaurant);
        bool DeleteRestaurant(int id);
    }
}
