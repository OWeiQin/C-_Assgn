//==========================================================
// Student Number : S10257453
// Student Name : Oh Wei Qin
// Partner Name : Shane
//==========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Shane

namespace IceCreamManagementSystem
{
    abstract class IceCream
    {
        public string Option { get; set; }
        public int Scoops { get; set; }
        public List<Flavour> flavours { get; set; } = new List<Flavour>();
        public List<Topping> toppings { get; set; } = new List<Topping>();
        public IceCream() { }
        public IceCream(string o, int s, List<Flavour> flavours, List<Topping> toppings)
        {
            Option = o;
            Scoops = s;
        }
        public abstract double CalculatePrice();
        public override string ToString()
        {
            return $"{"Option: "}{Option, -7}{"Scoops: "}{Scoops, -2}";
        }

    }
}
