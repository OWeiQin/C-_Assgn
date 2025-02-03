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

namespace IceCreamManagementSystem
{
    class PointCard
    {
        public int Points { get; set; }
        public int PunchCard { get; set; }
        public string Tier { get; set; }
        public PointCard() { }
        public PointCard(int p, int pc)
        {
            Points = p;
            PunchCard = pc;
        }
        public void AddPoints(int p)
        {
            Points += p;
        }
        public void RedeemPoints(int p)
        {
            Points -= p;
        }
        public void Punch()
        {
            PunchCard = 0;
        }
        public override string ToString()
        {
            return $"{"Points: "}{Points, -2}{"PunchCard: "}{PunchCard, -2}";
        }

    }
}
