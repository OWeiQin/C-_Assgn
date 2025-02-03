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
    class Customer
    {
        public string Name { get; set; }
        public int MemberID { get; set; }
        public DateTime Dob { get; set; }
        public Order CurrentOrder { get; set; }
        public List<Order> OrderHistory { get; set; } = new List<Order>();
        public PointCard Rewards { get; set; }
        public Customer() { }
        public Customer(string n, int mid, DateTime dob)
        {
            Name = n;
            MemberID = mid;
            Dob = dob;
        }
        public Order MakeOrder()
        {
            Order Norder = new Order(1, DateTime.Now.Date);
            OrderHistory.Add(Norder);
            
            return CurrentOrder;
        }
        public bool IsBirthday()
        {
            if (DateTime.Now == Dob)
            {
                return true;
            }
            else { return false; }
        }
        public override string ToString()
        {
            return $"{"Name: "}{Name, -10}{"ID: "}{MemberID, -7}{"Date of birth: "}{Dob.Date.ToString("dd/MM/yyyy"), -11}";
        }

    }
}
