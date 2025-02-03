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
    class Topping
    {
        public string Type { get; set; }
        public Topping() { }
        public Topping(string T)
        {
            Type = T;
        }
        public override string ToString()
        {
            return $"{"Type: "}{Type, -11}";
        }

    }
}
