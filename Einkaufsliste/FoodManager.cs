using Einkaufsliste.ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class FoodManager
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Foods.json";
        private ReadValues readValues = new ReadValues();
        public void createFood()
        {
            string name;
            double price;
            int weight;
            string priceString;
            FluentFood food = new FluentFood();
            List<Food> foods = getFoodList();

            name = readValues.ReadString();

            Console.WriteLine("Gib den Preis ein:");
            price = readValues.ReadDouble();

            Console.WriteLine("Gib das Gewicht des Essens ein:");
            weight = readValues.ReadInt();
            if(name != null)
            {
                food.NameOfTheFood(name).PriceOfTheFood(price).WeightOfTheFood(weight);

                Console.WriteLine(food);

                foods.Add(food.food);

                saveFoodList(foods);
            }
        }
        public void deleteFood(string name)
        {
            List<Food> foods = getFoodList();
            Food food = foods.Find(x => x.Name == name);

            foods.Remove(food);

            saveFoodList(foods);
        }

        public List<Food> getFoodList()
        {
            List<Food> foods = new List<Food>();
            using (StreamReader streamReader = new StreamReader(path))
            {
                string foodsString = streamReader.ReadToEnd();
                if (foodsString != "")
                {
                    foods = JsonSerializer.Deserialize<List<Food>>(foodsString);
                }
            }
            return foods;
        }

        public void readFoodList()
        {
            List<Food> foods = getFoodList();
            foreach(Food food in foods)
            {
                Console.WriteLine("Name: " + food.Name + " Preis: " + food.Price + " Gewicht: " + food.Weight);
            }
        }

        public void saveFoodList(List<Food> foods)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string jsonFoods = JsonSerializer.Serialize(foods);
                streamWriter.Write(jsonFoods);
            }
        }
    }
}
