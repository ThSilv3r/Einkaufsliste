using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Einkaufsliste.ClassLibrary
{
    public enum FoodType
    {
        Milch = 0,
        Getreide = 1,
        Fleisch = 2,
        Gemüse = 3,
        Obst = 4
    }
    public class Food : Product
    {
        public int Weight { get; set; }
        //public FoodType FoodType { get; set; }
    }
}
