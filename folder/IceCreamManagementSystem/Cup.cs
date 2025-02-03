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
    class Cup : IceCream
    {
        public Cup() { }
        public Cup(string o, int s, List<Flavour> flavours, List<Topping> toppings) : base(o, s, flavours, toppings) { }
        public override double CalculatePrice()
        {
            int count = toppings.Count;
            double price = 0;
            if (Scoops == 1)
            {
                price = 4;
                foreach (Flavour f in flavours)
                {
                    foreach (Topping t in toppings)
                    {
                        if (f.Premium == false)
                        {
                            break;
                        }
                        else if (f.Premium == true)
                        {
                            price += 2;
                        }
                        price += 1 * count;
                        break;
                    }
                    break;
                }
                return price;
            }
            else if (Scoops == 2)
            {
                price = 5.5;
                foreach (Flavour f in flavours)
                {
                    foreach (Topping t in toppings)
                    {
                        if (f.Premium == false)
                        {
                            continue;
                        }
                        else if (f.Premium == true)
                        {
                            price = 2;
                        }
                        price += 1 * count;
                        break;
                    }
                    break;
                }
                return price;
            }
            else if (Scoops == 3)
            {
                price = 6.5;
                foreach (Flavour f in flavours)
                {
                    foreach (Topping t in toppings)
                    {
                        if (f.Premium == false)
                        {
                            continue;
                        }
                        else if (f.Premium == true)
                        {
                            price += 2;
                        }
                        price += 1 * count;
                        break;
                    }
                    break;
                }
            }
            return price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
