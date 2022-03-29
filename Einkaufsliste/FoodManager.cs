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
        public void createFood()
        {
            string name;
            double price;
            int weight;
            string priceString;
            FluentFood food = new FluentFood();
            List<Food> foods = getFoodList();

            Console.WriteLine("Gib den Namen des Essens ein:");
            name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Bitte Versuche es erneut mit einem Namen.");
                return;
            }

            Console.WriteLine("Gib den Preis ein:");
            priceString = Console.ReadLine();
           // try
           // {
                price = Convert.ToDouble(priceString);
           // }
            //catch (Exception e)
            //{
                //Console.WriteLine("Bitte nur Zahlen eingeben:");
                //priceString = Console.ReadLine();
                //if (priceString == null)
                //{
                //    price = 0;
                //}
                //price = Convert.ToDouble(priceString);
            //}

            Console.WriteLine("Gib das Gewicht des Essens ein:");
            string weightString = Console.ReadLine();
            //try
            //{
                weight = Convert.ToInt32(weightString);
            //}
            //catch (Exception e)
            //{
            //    //Console.WriteLine("Bitte nur Zahlen eingeben:");
            //    //weightString = Console.ReadLine();
            //    //if (weightString == null)
            //    //{
            //    //    weight = 0;
            //    //}
            //    //weight = Convert.ToInt32(weightString);
            //}

            food.NameOfTheFood(name).PriceOfTheFood(price).WeightOfTheFood(weight);

            Console.WriteLine(food);

            foods.Add(food.food);

            saveFoodList(foods);
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
