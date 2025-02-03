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
    class Flavour
    {
        public string Type { get; set; }
        public bool Premium { get; set; }
        public int Quantity { get; set; }
        
        public Flavour() { }
        public Flavour(string t, bool prem, int q)
        {
            Type = t;
            Premium = prem;
            Quantity = q;
        }
        public override string ToString()
        {
            return $"{"Type: "}{Type, -11}{"Premium: "}{Premium, -6}{"Quantity: "}{Quantity, -3}";
        }

    }
}
