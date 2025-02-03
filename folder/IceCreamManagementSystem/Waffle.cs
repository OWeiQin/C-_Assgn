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

//Wei Qin

namespace IceCreamManagementSystem
{
    class Waffle : IceCream
    {
        public string WaffleFlavour { get; set; }
        public Waffle() { }
        public Waffle(string o, int s, List<Flavour> flavours, List<Topping> toppings, string wf) : base(o, s, flavours, toppings)
        {
            WaffleFlavour = wf;
        }
        public override double CalculatePrice()
        {
            int count = toppings.Count;
            double price = 0;
            if (WaffleFlavour != null)
            {
                if (Scoops == 1)
                {
                    price = 10;
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
                    price = 11.5;
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
                    price = 12.5;
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
                
            }
            else if (WaffleFlavour == null)
            {
                if (Scoops == 1)
                {
                    price = 7;
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
                    price = 8.5;
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
                    price = 9.5;
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
            return price;
        }

    }
}
