using Einkaufsliste.ClassLibrary;
using Einkaufsliste.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Einkaufsliste
{
    public class FoodManager : IFoodManager
    {
        private string path = @"C:\Users\user\source\repos\Einkaufsliste\Einkaufsliste\Foods.json";
        private ReadValues readValues = new ReadValues();
        public void createFood()
        {
            string name;
            double price;
            int weight;
            FluentFood food = new FluentFood();
            List<Food> foods = getFoodList();

            name = readValues.ReadString();

            Console.WriteLine("Enter the price:");
            price = readValues.ReadDouble();

            Console.WriteLine("Enter the weight of the food:");
            weight = readValues.ReadInt();
            if(name != null)
            {
                food.NameOfTheFood(name).PriceOfTheFood(price).WeightOfTheFood(weight);

                Console.WriteLine(food);

                foods.Add(food.food);

                saveFood(foods);
            }
        }
        public void deleteFood(string name)
        {
            List<Food> foods = getFoodList();
            Food food = foods.Find(x => x.Name == name);

            foods.Remove(food);

            saveFood(foods);
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
                Console.WriteLine("Name: " + food.Name + " Price: " + food.Price + " Weight: " + food.Weight);
            }
        }

        public void saveFood(List<Food> foods)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string jsonFoods = JsonSerializer.Serialize(foods);
                streamWriter.Write(jsonFoods);
            }
        }
    }
}
