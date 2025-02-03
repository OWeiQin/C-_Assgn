//==========================================================
// Student Number : S10257453
// Student Name : Oh Wei Qin
// Partner Name : Shane
//==========================================================

using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

//Wei Qin

namespace IceCreamManagementSystem
{
    class Order
    {
        public int Id { get; set; }
        public DateTime TimeReceived { get; set; }
        public DateTime? TimeFulfilled { get; set; }
        public List<IceCream> IceCreamList { get; set; } = new List<IceCream>();
        public Order() { }
        public Order(int id, DateTime tr)
        {
            Id = id;
            TimeReceived = tr;
        }
        public void ModifyIceCream(int n)
        {
            Console.WriteLine("[1] Modify existing ice-cream");
            Console.WriteLine("[2] Add new ice-cream order");
            Console.WriteLine("[3] Remove ice-cream");
            Console.Write("Enter an option: ");
            string opt = Console.ReadLine();
            while (true)
            {
                if (opt == "1")
                {
                    if (IceCreamList.Count == 0)
                    {
                        Console.WriteLine("There is currently zero order. Please make an order first.");
                    }
                    else
                    {
                        for (int i = 0; i < IceCreamList.Count; i++)
                        {
                            Console.WriteLine("Order {0}: ", (i+1));
                            Console.WriteLine("Option: {0}", IceCreamList[i].Option);
                            Console.WriteLine("Number of scoops: {0}", IceCreamList[i].Scoops);
                            for (int j = 0; j < IceCreamList[i].Scoops; j++)
                            {
                                Console.WriteLine("Scoop{0}: {1}", (j + 1), IceCreamList[i].flavours[j]);
                            }
                            Console.WriteLine("Number of toppings: {0}", IceCreamList[i].toppings.Count);
                            for (int j = 0; j < IceCreamList[i].toppings.Count; j++)
                            {
                                Console.WriteLine("Topping{0}: {1}", (j + 1), IceCreamList[i].toppings[j]);
                            }
                            if (IceCreamList[i] is Cone)
                            {
                                Cone c = (Cone)IceCreamList[i];
                                Console.WriteLine("Cone dipped: {0}", c.Dipped);
                            }
                            else if (IceCreamList[i] is Waffle)
                            {
                                Waffle w = (Waffle)IceCreamList[i];
                                Console.WriteLine("Waffle flavour: {0}", w.WaffleFlavour);
                            }
                        }
                        Console.WriteLine("[1] Cup");
                        Console.WriteLine("[2] Cone");
                        Console.WriteLine("[3] Waffle");
                        Console.Write("Option to modify ice cream: ");
                        string mOption = Console.ReadLine();
                        if (mOption == "2")
                        {
                            Cone c = (Cone)IceCreamList[n - 1];
                            IceCreamList[n - 1].Option = "Cone";
                            while (true)
                            {
                                Console.Write("Dipped cone? (Y/N): ");
                                string dip = Console.ReadLine();
                                if (dip.ToUpper() == "Y")
                                {
                                    c.Dipped = true;
                                    break;
                                }
                                else if (dip.ToUpper() == "N")
                                {
                                    c.Dipped = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option.");
                                    continue;
                                }
                            }
                        }
                        else if (mOption == "3")
                        {
                            Waffle w = (Waffle)IceCreamList[n - 1];
                            IceCreamList[n - 1].Option = "Waffle";
                            while (true)
                            {
                                Console.Write("Different waffle flavour? (Y/N): ");
                                string wflavour = Console.ReadLine();
                                if (wflavour.ToUpper() == "Y")
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("[1] Red Velvet [2] Charcoal [3] Pandan");
                                        Console.Write("Enter flavour option: ");
                                        string wflavouropt = Console.ReadLine();
                                        if (wflavouropt == "1")
                                        {
                                            w.WaffleFlavour = "Red velvet";
                                            break;
                                        }
                                        else if (wflavouropt == "2")
                                        {
                                            w.WaffleFlavour = "Charcoal";
                                            break;
                                        }
                                        else if (wflavouropt == "3")
                                        {
                                            w.WaffleFlavour = "Pandan";
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a valid waffle flavour.");
                                            continue;
                                        }
                                    }
                                    break;
                                }
                                else if (wflavour.ToUpper() == "N")
                                {
                                    w.WaffleFlavour = "Original";
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter a valid option.");
                                    continue;
                                }
                            }
                        }
                        else if (mOption != "1")
                        {
                            Console.WriteLine("Please enter a valid option.");
                        }
                        while (true)
                        {
                            Console.Write("Change the number of scoops? (Y/N): ");
                            string ans = Console.ReadLine();
                            if (ans.ToUpper() == "N")
                            {
                                break;
                            }
                            else if (ans.ToUpper() == "Y")
                            {
                                IceCreamList[n - 1].flavours.Clear();
                                while (true)
                                {
                                    Console.Write("Enter number of scoops: ");
                                    int nScoops = Convert.ToInt32(Console.ReadLine());
                                    if (nScoops == 1)
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                            Console.Write("Enter choice of flavour: ");
                                            string fchoice = Console.ReadLine();
                                            if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                            {
                                                IceCreamList[n - 1].flavours.Add(new Flavour(fchoice, false, nScoops));
                                            }
                                            else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                            {
                                                IceCreamList[n - 1].flavours.Add(new Flavour(fchoice, true, nScoops));
                                            }
                                            else
                                            {
                                                Console.WriteLine("Please enter a valid flavour");
                                            }
                                            break;
                                        }
                                    }
                                    if (nScoops == 2)
                                    {
                                        while (true)
                                        {
                                            while (nScoops > 0)
                                            {
                                                Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                                Console.Write("Enter choice of flavour: ");
                                                string fchoice = Console.ReadLine();
                                                if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                                {
                                                    Console.Write("Enter number of {0} scoops", fchoice);
                                                    int count = Convert.ToInt32(Console.ReadLine());
                                                    IceCreamList[n - 1].flavours.Add(new Flavour(fchoice, false, count));
                                                    nScoops -= count;
                                                }
                                                else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                                {
                                                    Console.Write("Enter number of {0} scoops", fchoice);
                                                    int count = Convert.ToInt32(Console.ReadLine());
                                                    IceCreamList[n - 1].flavours.Add(new Flavour(fchoice, true, count));
                                                    nScoops -= count;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Please enter a valid flavour");
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    else if (nScoops == 3)
                                    {
                                        while (true)
                                        {
                                            while (nScoops > 0)
                                            {
                                                Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                                Console.Write("Enter choice of flavour: ");
                                                string fchoice = Console.ReadLine();
                                                if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                                {
                                                    Console.Write("Enter number of {0} scoops", fchoice);
                                                    int count = Convert.ToInt32(Console.ReadLine());
                                                    IceCreamList[n - 1].flavours.Add(new Flavour(fchoice, false, count));
                                                    nScoops -= count;
                                                }
                                                else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                                {
                                                    Console.Write("Enter number of {0} scoops", fchoice);
                                                    int count = Convert.ToInt32(Console.ReadLine());
                                                    IceCreamList[n - 1].flavours.Add(new Flavour(fchoice, true, count));
                                                    nScoops -= count;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Please enter a valid flavour");
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter between 1 to 3 flavours.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid answer.");
                                continue;
                            }
                        }
                        while (true)
                        {
                            Console.Write("Change the number of toppings? (Y/N): ");
                            string ctop = Console.ReadLine();
                            if (ctop.ToUpper() == "N")
                            {
                                break;
                            }
                            else if (ctop.ToUpper() == "Y")
                            {
                                IceCreamList[n - 1].toppings.Clear();
                                int ntoppings = 0;
                                while (true)
                                {
                                    Console.Write("Enter number of toppings: ");
                                    ntoppings = Convert.ToInt32(Console.ReadLine());
                                    
                                    while (true)
                                    {
                                        while (ntoppings > 0)
                                        {
                                            Console.WriteLine($"Sprinkles\nMochi\nSago\nOreos");
                                            Console.Write("Enter choice of topping: ");
                                            string tchoice = Console.ReadLine();
                                            if (tchoice == "Sprinkles" || tchoice == "Mochi" || tchoice == "Sago" || tchoice == "Oreos")
                                            {
                                                IceCreamList[n - 1].toppings.Add(new Topping(tchoice));
                                                ntoppings--;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Please enter a valid topping.");
                                                continue;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid answer.");
                                continue;
                            }
                        }
                    }
                }
                else if (opt == "2")
                {
                    Console.WriteLine("\n[1] Cup\n[2] Cone\n[3] Waffle");
                    Console.Write("Enter ice cream option: ");
                    string newopt = Console.ReadLine();
                    if (newopt == "2")
                    {
                        Cone c = new Cone();
                        IceCreamList.Add(c);
                        Cone nc = (Cone)IceCreamList[IceCreamList.IndexOf(c)];
                        nc.Option = "Cone";
                        while (true)
                        {
                            Console.Write("Dipped cone? (Y/N): ");
                            string dip = Console.ReadLine();
                            if (dip.ToUpper() == "Y")
                            {
                                nc.Dipped = true;
                                break;
                            }
                            else if (dip.ToUpper() == "N")
                            {
                                nc.Dipped = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid option.");
                                continue;
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter number of scoops: ");
                            int nScoops = Convert.ToInt32(Console.ReadLine());
                            if (nScoops == 1)
                            {
                                while (true)
                                {
                                    Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                    Console.Write("Enter choice of flavour: ");
                                    string fchoice = Console.ReadLine();
                                    if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                    {
                                        nc.flavours.Add(new Flavour(fchoice, false, nScoops));
                                    }
                                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                    {
                                        nc.flavours.Add(new Flavour(fchoice, true, nScoops));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid flavour");
                                    }
                                    break;
                                }
                            }
                            else if (nScoops == 2)
                            {
                                while (true)
                                {
                                    while (nScoops > 0)
                                    {
                                        Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                        Console.Write("Enter choice of flavour: ");
                                        string fchoice = Console.ReadLine();
                                        if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nc.flavours.Add(new Flavour(fchoice, false, count));
                                            nScoops -= count;
                                        }
                                        else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nc.flavours.Add(new Flavour(fchoice, true, count));
                                            nScoops -= count;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a valid flavour");
                                        }
                                    }
                                    break;
                                }
                            }
                            else if (nScoops == 3)
                            {
                                while (true)
                                {
                                    while (nScoops > 0)
                                    {
                                        Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                        Console.Write("Enter choice of flavour: ");
                                        string fchoice = Console.ReadLine();
                                        if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nc.flavours.Add(new Flavour(fchoice, false, count));
                                            nScoops -= count;
                                        }
                                        else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nc.flavours.Add(new Flavour(fchoice, true, count));
                                            nScoops -= count;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a valid flavour");
                                        }
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter between 1 to 3 flavours.");
                            }
                            break;
                        }
                        int ntopping = 0;
                        while (true)
                        {
                            Console.Write("Enter number of toppings: ");
                            ntopping = Convert.ToInt32(Console.ReadLine());
                            while (true)
                            {
                                while (ntopping > 0)
                                {
                                    Console.WriteLine($"Sprinkles\nMochi\nSago\nOreos");
                                    Console.Write("Enter choice of topping: ");
                                    string tchoice = Console.ReadLine();
                                    if (tchoice == "Sprinkles" || tchoice == "Mochi" || tchoice == "Sago" || tchoice == "Oreos")
                                    {
                                        nc.toppings.Add(new Topping(tchoice));
                                        ntopping--;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid topping.");
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                    else if (newopt == "3")
                    {
                        Waffle w = new Waffle();
                        IceCreamList.Add(w);
                        Waffle nw = (Waffle)IceCreamList[IceCreamList.IndexOf(w)];
                        nw.Option = "Waffle";
                        while (true)
                        {
                            Console.Write("Different waffle flavour? (Y/N): ");
                            string wflavour = Console.ReadLine();
                            if (wflavour.ToUpper() == "Y")
                            {
                                while (true)
                                {
                                    Console.WriteLine("[1] Red Velvet [2] Charcoal [3] Pandan");
                                    Console.Write("Enter flavour option: ");
                                    string wflavouropt = Console.ReadLine();
                                    if (wflavouropt == "1")
                                    {
                                        nw.WaffleFlavour = "Red velvet";
                                        break;
                                    }
                                    else if (wflavouropt == "2")
                                    {
                                        nw.WaffleFlavour = "Charcoal";
                                        break;
                                    }
                                    else if (wflavouropt == "3")
                                    {
                                        nw.WaffleFlavour = "Pandan";
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid waffle flavour.");
                                        continue;
                                    }
                                }
                                break;
                            }
                            else if (wflavour.ToUpper() == "N")
                            {
                                nw.WaffleFlavour = "Original";
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid option.");
                                continue;
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter number of scoops: ");
                            int nScoops = Convert.ToInt32(Console.ReadLine());
                            if (nScoops == 1)
                            {
                                while (true)
                                {
                                    Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                    Console.Write("Enter choice of flavour: ");
                                    string fchoice = Console.ReadLine();
                                    if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                    {
                                        nw.flavours.Add(new Flavour(fchoice, false, nScoops));
                                    }
                                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                    {
                                        nw.flavours.Add(new Flavour(fchoice, true, nScoops));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid flavour");
                                    }
                                    break;
                                }
                            }
                            else if (nScoops == 2)
                            {
                                while (true)
                                {
                                    while (nScoops > 0)
                                    {
                                        Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                        Console.Write("Enter choice of flavour: ");
                                        string fchoice = Console.ReadLine();
                                        if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nw.flavours.Add(new Flavour(fchoice, false, count));
                                            nScoops -= count;
                                        }
                                        else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nw.flavours.Add(new Flavour(fchoice, true, count));
                                            nScoops -= count;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a valid flavour");
                                        }
                                    }
                                    break;
                                }
                            }
                            else if (nScoops == 3)
                            {
                                while (true)
                                {
                                    while (nScoops > 0)
                                    {
                                        Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                                        Console.Write("Enter choice of flavour: ");
                                        string fchoice = Console.ReadLine();
                                        if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nw.flavours.Add(new Flavour(fchoice, false, count));
                                            nScoops -= count;
                                        }
                                        else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                                        {
                                            Console.Write("Enter number of {0} scoops", fchoice);
                                            int count = Convert.ToInt32(Console.ReadLine());
                                            nw.flavours.Add(new Flavour(fchoice, true, count));
                                            nScoops -= count;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please enter a valid flavour");
                                        }
                                    }
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter between 1 to 3 flavours.");
                            }
                            break;
                        }
                        int ntopping = 0;
                        while (true)
                        {
                            Console.Write("Enter number of toppings: ");
                            ntopping = Convert.ToInt32(Console.ReadLine());
                            while (true)
                            {
                                while (ntopping > 0)
                                {
                                    Console.WriteLine($"Sprinkles\nMochi\nSago\nOreos");
                                    Console.Write("Enter choice of topping: ");
                                    string tchoice = Console.ReadLine();
                                    if (tchoice == "Sprinkles" || tchoice == "Mochi" || tchoice == "Sago" || tchoice == "Oreos")
                                    {
                                        nw.toppings.Add(new Topping(tchoice));
                                        ntopping--;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a valid topping.");
                                        continue;
                                    }
                                }
                            }
                        }
                    }
                }
                else if (opt == "3")
                {
                    if (IceCreamList.Count == 0)
                    {
                        Console.WriteLine("Order cannot be empty!");
                    }
                    else
                    {
                        for (int i = 0; i < IceCreamList.Count; i++)
                        {
                            Console.WriteLine("Order {0}: ", (i + 1));
                            Console.WriteLine("Option: {0}", IceCreamList[i].Option);
                            Console.WriteLine("Number of scoops: {0}", IceCreamList[i].Scoops);
                            for (int j = 0; j < IceCreamList[i].Scoops; j++)
                            {
                                Console.WriteLine("Scoop{0}: {1}", (j + 1), IceCreamList[i].flavours[j]);
                            }
                            Console.WriteLine("Number of toppings: {0}", IceCreamList[i].toppings.Count);
                            for (int j = 0; j < IceCreamList[i].toppings.Count; j++)
                            {
                                Console.WriteLine("Topping{0}: {1}", (j + 1), IceCreamList[i].toppings[j]);
                            }
                            if (IceCreamList[i] is Cone)
                            {
                                Cone c = (Cone)IceCreamList[i];
                                Console.WriteLine("Cone dipped: {0}", c.Dipped);
                            }
                            else if (IceCreamList[i] is Waffle)
                            {
                                Waffle w = (Waffle)IceCreamList[i];
                                Console.WriteLine("Waffle flavour: {0}", w.WaffleFlavour);
                            }
                        }
                        while (true)
                        {
                            Console.Write("Enter order number to delete: ");
                            int del = Convert.ToInt32(Console.ReadLine());
                            if (del >= 0)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        IceCreamList.RemoveAt(del);
                                        Console.WriteLine("Order deleted successfully!");
                                        break;
                                    }
                                    catch (IndexOutOfRangeException ex)
                                    {
                                        Console.WriteLine("Order number not found");
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter a number!");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option entered! Please enter again!");
                    continue;
                }
            }
        }
        public void AddIceCream(IceCream ic)
        {
            IceCreamList.Add(ic);
        }
        public void DeleteIceCream(int n)
        {
            IceCreamList.RemoveAt(n);
        }
        public double CalculateTotal()
        {
            double total = 0;
            foreach (IceCream ic in IceCreamList)
            {
                if (ic is Cup)
                {
                    Cup cup = (Cup)ic;
                    total += cup.CalculatePrice();
                }
                else if (ic is Cone)
                {
                    Cone cone = (Cone)ic;
                    total += cone.CalculatePrice();
                }
                else
                {
                    Waffle w = (Waffle)ic;
                    total += w.CalculatePrice();
                }
            }

            return total;
        }
        public override string ToString()
        {
            return $"{"ID: "}{Id, -3}{"Time Received: "}{TimeReceived, -22}{"Time Fulfilled: "}{TimeFulfilled, -21}";
        }

    }
}
