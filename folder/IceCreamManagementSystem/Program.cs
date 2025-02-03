// See https://aka.ms/new-console-template for more information
//==========================================================
// Student Number : S10257453
// Student Name : Oh Wei Qin
// Partner Name : Shane
//==========================================================

using IceCreamManagementSystem;

void DisplayMenu()
{
    Console.WriteLine("---------MENU---------");
    Console.WriteLine("----------------------");
    Console.WriteLine("[1] Display information of all customers");
    Console.WriteLine("[2] Display all current orders");
    Console.WriteLine("[3] Register a new customer");
    Console.WriteLine("[4] Create a customer's order");
    Console.WriteLine("[5] Display order details");
    Console.WriteLine("[6] Modify order details");
    Console.WriteLine("[7] Process order and Checkout");
    Console.WriteLine("[8] Display monthly charged amounts breakdown & Total charged amounts for the year");
    Console.WriteLine("[0] Exit");
    Console.WriteLine();
}

string[] data = File.ReadAllLines("customers.csv");
string[] ord = File.ReadAllLines("orders.csv");
string[] flav = File.ReadAllLines("flavours.csv");
string[] top = File.ReadAllLines("toppings.csv");
Queue<Order> OrdQueue = new Queue<Order>();
Queue<Order> GoldQueue = new Queue<Order>();
List<string> cuslist = new List<string>();
List<Customer> customerlist = new List<Customer>();
List<PointCard> pointcardslist = new List<PointCard>();

//New cup order
Cup newCup(string opt, Order newOrd, bool tier)
{
    opt = "Cup";
    List<Flavour> flavour = new List<Flavour>();
    List<Topping> topping = new List<Topping>();
    int nScoops = 0;
    int ntoppings = 0;
    while (true)
    {
        Console.Write("Enter number of scoops: ");
        nScoops = Convert.ToInt32(Console.ReadLine());
        if (nScoops == 1)
        {
            while (true)
            {
                Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                Console.Write("Enter choice of flavour: ");
                string fchoice = Console.ReadLine();
                if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                {
                    flavour.Add(new Flavour(fchoice, false, nScoops));
                }
                else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                {
                    flavour.Add(new Flavour(fchoice, true, nScoops));
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
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, false, count));
                        nScoops -= count;
                    }
                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                    {
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, true, count));
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
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, false, count));
                        nScoops -= count;
                    }
                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                    {
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, true, count));
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
                    topping.Add(new Topping(tchoice));
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
        break;
    }
    Cup cup = new Cup(opt, nScoops, flavour, topping);
    newOrd.TimeFulfilled = DateTime.Now;
    newOrd.AddIceCream(cup);
    return cup;
}

//New cone order
Cone newCone(string opt, Order newOrd, bool tier)
{
    opt = "Cone";
    int nScoops = 0;
    int ntoppings = 0;
    List<Flavour> flavour = new List<Flavour>();
    List<Topping> topping = new List<Topping>();
    bool dipp = false;
    while (true)
    {
        Console.Write("Dipped cone? (Y/N): ");
        string dip = Console.ReadLine();
        if (dip.ToUpper() == "Y")
        {
            dipp = true;
            break;
        }
        else if (dip.ToUpper() == "N")
        {
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
        nScoops = Convert.ToInt32(Console.ReadLine());
        if (nScoops == 1)
        {
            while (true)
            {
                Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                Console.Write("Enter choice of flavour: ");
                string fchoice = Console.ReadLine();
                if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                {
                    flavour.Add(new Flavour(fchoice, false, nScoops));
                }
                else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                {
                    flavour.Add(new Flavour(fchoice, true, nScoops));
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
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, false, count));
                        nScoops -= count;
                    }
                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                    {
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, true, count));
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
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, false, count));
                        nScoops -= count;
                    }
                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                    {
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, true, count));
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
                    topping.Add(new Topping(tchoice));
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
        break;
    }
    Cone cone = new Cone(opt, nScoops, flavour, topping, dipp);
    newOrd.TimeFulfilled = DateTime.Now;
    newOrd.AddIceCream(cone);
    return cone;
}

//New waffle
Waffle newWaffle(string opt, Order newOrd, bool tier)
{
    opt = "Waffle";
    int nScoops = 0;
    int ntoppings = 0;
    List<Flavour> flavour = new List<Flavour>();
    List<Topping> topping = new List<Topping>();
    string wflavouropt = "";
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
                wflavouropt = Console.ReadLine();
                if (wflavouropt == "1")
                {
                    wflavouropt = "Red velvet";
                    break;
                }
                else if (wflavouropt == "2")
                {
                    wflavouropt = "Charcoal";
                    break;
                }
                else if (wflavouropt == "3")
                {
                    wflavouropt = "Pandan";
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
            wflavouropt = "Original";
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
        nScoops = Convert.ToInt32(Console.ReadLine());
        if (nScoops == 1)
        {
            while (true)
            {
                Console.WriteLine($"Vanilla\nChocolate\nStrawberry\nDurian\nUbe\nSea Salt");
                Console.Write("Enter choice of flavour: ");
                string fchoice = Console.ReadLine();
                if (fchoice == "Vanilla" || fchoice == "Chocolate" || fchoice == "Strawberry")
                {
                    flavour.Add(new Flavour(fchoice, false, nScoops));
                }
                else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                {
                    flavour.Add(new Flavour(fchoice, true, nScoops));
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
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, false, count));
                        nScoops -= count;
                    }
                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                    {
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, true, count));
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
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, false, count));
                        nScoops -= count;
                    }
                    else if (fchoice == "Durian" || fchoice == "Ube" || fchoice == "Sea Salt")
                    {
                        Console.Write("Enter number of {0} scoops: ", fchoice);
                        int count = Convert.ToInt32(Console.ReadLine());
                        flavour.Add(new Flavour(fchoice, true, count));
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
                    topping.Add(new Topping(tchoice));
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
        break;
    }
    Waffle w = new Waffle(opt, nScoops, flavour, topping, wflavouropt);
    newOrd.TimeFulfilled = DateTime.Now;
    newOrd.AddIceCream(w);
    return w;
}

//Option 1
void DisplayCustomers()
{
    Console.WriteLine("{0,-10} {1,-8} {2,-11} {3,-16} {4,-16} {5,-9}", "Name", "MemberID", "DateOfBirth", "MembershipStatus", "MembershipPoints", "PunchCard");
    for (int i = 1; i < data.Length; i++)
    {
        string[] info = data[i].Split(',');
        Console.WriteLine("{0,-10} {1,-8} {2,-11} {3,-16} {4,-16} {5,-9}", info[0], info[1], info[2], info[3], info[4], info[5]);
    }
}

//Option 2
void DisplayOrders()
{
    string[] head = ord[0].Split(",");
    Console.WriteLine("{0,3} {1,9} {2,21} {3,21} {4,7} {5,7} {6,7} {7,14} {8,11} {9,11} {10,11} {11,11} {12,10} {13,10} {14,10}",
        "ID", "MemberID", "TimeReceived", "TimeFufilled", "Option", "Scoops", "Dipped", "WaffleFlavour", "Flavour1", "Flavour2", "Flavour3",
        "Topping1", "Topping2", "Topping3", "Topping4");

    for (int j = 1; j < ord.Length; j++)
    {    
        string[] info = ord[j].Split(",");
        Console.WriteLine("{0,3} {1,9} {2,21} {3,21} {4,7} {5,7} {6,7} {7,14} {8,11} {9,11} {10,11} {11,11} {12,10} {13,10} {14,10}",
            info[0], info[1], info[2], info[3], info[4], info[5], info[6], info[7], info[8], info[9], info[10], info[11], info[12], info[13], info[14]);
        
    }
}

//Option 3
void RegisterCus()
{
    while (true)
    {
        Console.Write("Enter name: ");
        string? n = Console.ReadLine();
        if (IsAlpha(n) == true)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter member id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    if (id.ToString().Length == 6)
                    {
                        while (true)
                        {
                            try
                            {
                                Console.Write("Enter date of birth(dd/MM/yyyy): ");
                                DateTime dt = Convert.ToDateTime(Console.ReadLine());
                                Customer c = new Customer(n, id, dt);
                                PointCard pc = new PointCard(0, 0);
                                c.Rewards = pc;
                                string s = n + "," + id + "," + dt.ToString("dd/MM/yyyy") + "," + "Ordinary" + "," + pc.Points + "," + pc.PunchCard;
                                using (StreamWriter sw = new StreamWriter("customers.csv", true))
                                {
                                    sw.WriteLine(s);
                                }
                                Console.WriteLine("Registration successful!");
                                break;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a 6 digit member id!");
                        continue;
                    }
                    
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            }
        }
        else
        {
            Console.WriteLine("Input name must be in letters!");
        }
        break;
    }
}

//Option 4
void CusOrder()
{
    DisplayCustomers();
    Console.Write("Enter a customer: ");
    string cus = Console.ReadLine();
    Order newOrd = new Order();
    bool findcus = false;
    bool tier = false;
    int id = Convert.ToInt32(ord[ord.Length - 1].Split(',')[0]);
    string mID = "";
    for (int i = 1; i < data.Length; i++)
    {
        if (data[i].Split(',')[0] == cus)
        {
            findcus = true;
            mID = data[i].Split(",")[1];
            newOrd.Id = Convert.ToInt32(mID);
            if (data[i].Split(',')[3].Contains("Gold"))
            {
                tier = true;
            }
        }
    }
    if (findcus == false)
    {
        Console.WriteLine("Customer not found!");
    }
    else
    {
        while (true)
        {
            Console.WriteLine("[1] Cup");
            Console.WriteLine("[2] Cone");
            Console.WriteLine("[3] Waffle");
            Console.Write("Enter ice cream option: ");
            string opt = Console.ReadLine();
            newOrd.TimeReceived = DateTime.Now;
            if (opt == "1")
            {
                using (StreamWriter sw = new StreamWriter("orders.csv", true))
                {
                    sw.Write($"{id++},");
                }
                Cup cupord = newCup(opt, newOrd, tier);
                if (cupord.flavours.Count == 1)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Cup"},{cupord.Scoops},,,{cupord.flavours[0].Type},,,");
                    }
                }
                else if (cupord.flavours.Count == 2)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Cup"},{cupord.Scoops},,,{cupord.flavours[0].Type},{cupord.flavours[1].Type},,");
                    }
                }
                else if (cupord.flavours.Count == 3)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Cup"},{cupord.Scoops},,,{cupord.flavours[0].Type},{cupord.flavours[1].Type},{cupord.flavours[2].Type},");
                    }
                }
                if (cupord.toppings.Count == 0)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($",,,");
                    }
                }
                else if (cupord.toppings.Count == 1)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{cupord.toppings[0].Type},,,");
                    }
                }
                else if (cupord.toppings.Count == 2)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{cupord.toppings[0].Type},{cupord.toppings[1].Type},,");
                    }
                }
                else if (cupord.toppings.Count == 3)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{cupord.toppings[0].Type},{cupord.toppings[1].Type},{cupord.toppings[2].Type},");
                    }
                }
                else if (cupord.toppings.Count == 4)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{cupord.toppings[0].Type},{cupord.toppings[1].Type},{cupord.toppings[2].Type},{cupord.toppings[3].Type}");
                    }
                }
            }
            else if (opt == "2")
            {
                using (StreamWriter sw = new StreamWriter("orders.csv", true))
                {
                    sw.Write($"{id++},");
                }
                Cone coneord = newCone(opt, newOrd, tier);
                if (coneord.flavours.Count == 1)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Cone"},{coneord.Scoops},{coneord.Dipped},,{coneord.flavours[0].Type},,,");
                    }
                }
                else if (coneord.flavours.Count == 2)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Cone"},{coneord.Scoops},{coneord.Dipped},,{coneord.flavours[0].Type},{coneord.flavours[1].Type},,");
                    }
                }
                else if (coneord.flavours.Count == 3)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Cone"},{coneord.Scoops},{coneord.Dipped},,{coneord.flavours[0].Type},{coneord.flavours[1].Type},{coneord.flavours[2].Type},");
                    }
                }
                if (coneord.toppings.Count == 0)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($",,,");
                    }
                }
                else if (coneord.toppings.Count == 1)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{coneord.toppings[0].Type},,,");
                    }
                }
                else if (coneord.toppings.Count == 2)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{coneord.toppings[0].Type},{coneord.toppings[1].Type},,");
                    }
                }
                else if (coneord.toppings.Count == 3)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{coneord.toppings[0].Type},{coneord.toppings[1].Type},{coneord.toppings[2].Type},");
                    }
                }
                else if (coneord.toppings.Count == 4)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{coneord.toppings[0].Type},{coneord.toppings[1].Type},{coneord.toppings[2].Type},{coneord.toppings[3].Type}");
                    }
                }
            }
            else if (opt == "3")
            {
                using (StreamWriter sw = new StreamWriter("orders.csv", true))
                {
                    sw.Write($"{id++},");
                }
                Waffle wOrd = newWaffle(opt, newOrd, tier);
                if (wOrd.flavours.Count == 0)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Waffle"},{wOrd.Scoops},,{wOrd.WaffleFlavour},{wOrd.flavours[0].Type},,,");
                    }
                }
                else if (wOrd.flavours.Count == 1)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Waffle"},{wOrd.Scoops},,{wOrd.WaffleFlavour},{wOrd.flavours[0].Type},{wOrd.flavours[1].Type},,");
                    }
                }
                else if (wOrd.flavours.Count == 2)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.Write($"{mID},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{DateTime.Now.ToString("dd/MM/yyyy HH:mm")},{"Waffle"},{wOrd.Scoops},,{wOrd.WaffleFlavour},{wOrd.flavours[0].Type},{wOrd.flavours[1].Type},{wOrd.flavours[2].Type},");
                    }
                }
                if (wOrd.toppings.Count == 0)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($",,,");
                    }
                }
                else if (wOrd.toppings.Count == 1)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{wOrd.toppings[0].Type},,,");
                    }
                }
                else if (wOrd.toppings.Count == 2)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{wOrd.toppings[0].Type},{wOrd.toppings[1].Type},,");
                    }
                }
                else if (wOrd.toppings.Count == 3)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{wOrd.toppings[0].Type},{wOrd.toppings[1].Type},{wOrd.toppings[2].Type},");
                    }
                }
                else if (wOrd.toppings.Count == 4)
                {
                    using (StreamWriter sw = new StreamWriter("orders.csv", true))
                    {
                        sw.WriteLine($"{wOrd.toppings[0].Type},{wOrd.toppings[1].Type},{wOrd.toppings[2].Type},{wOrd.toppings[3].Type}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid option entered! Please try again.");
            }
            string addord = "";
            while (true)
            {
                Console.Write("Would you like to add another ice cream to the order? (Y/N): ");
                addord = Console.ReadLine();
                if (addord.ToUpper() == "Y" || addord.ToUpper() == "N")
                {
                    if (tier == true)
                    {
                        GoldQueue.Enqueue(newOrd);
                    }
                    else
                    {
                        OrdQueue.Enqueue(newOrd);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid answer entered! Please enter again.");
                }
            }
            if (addord.ToUpper() == "N")
            {
                break;
            }
        }
        Console.WriteLine("Order(s) has been made successfully!");
    }
}

//Option 5
void DisplayOrdDetails()
{
    while (true)
    {
        Console.Write("Enter a customer: ");
        string cus = Console.ReadLine();
        for (int i = 1; i < data.Length; i++)
        {
            if (data[i].Split(',')[0] == cus)
            {
                string memid = data[i].Split(',')[1];
                for (int j = 1; j < ord.Length; j++)
                {
                    if (memid == ord[j].Split(",")[1])
                    {
                        Console.WriteLine("{0,3} {1,9} {2,21} {3,21} {4,7} {5,7} {6,7} {7,14} {8,11} {9,11} {10,11} {11,11} {12,10} {13,10} {14,10}",
        "ID", "MemberID", "TimeReceived", "TimeFufilled", "Option", "Scoops", "Dipped", "WaffleFlavour", "Flavour1", "Flavour2", "Flavour3",
        "Topping1", "Topping2", "Topping3", "Topping4");
                        string[] infos = data[i].Split(",");
                        Customer customer = new Customer(infos[0], Convert.ToInt32(infos[1]), Convert.ToDateTime(infos[2]));
                        string[] info = ord[j].Split(",");
                        Order order = new Order(Convert.ToInt32(info[0]), Convert.ToDateTime(info[2]));
                        Console.WriteLine("{0,3} {1,9} {2,21} {3,21} {4,7} {5,7} {6,7} {7,14} {8,11} {9,11} {10,11} {11,11} {12,10} {13,10} {14,10}",
                            order.Id, customer.MemberID, order.TimeReceived, info[3], info[4], info[5], info[6], info[7], info[8], info[9], info[10], info[11], info[12], info[13], info[14]);
                        break;
                    }
                }
                break;
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }
        break;
    }
}

//Option 6
void ModifyOrder()
{
    DisplayCustomers();
    List<Order> ordlist = new List<Order>();
    Console.Write("Enter customer name: ");
    string cus = Console.ReadLine();
    string mID = "";
    bool findcus = false;
    List<IceCream> IClist = new List<IceCream>();
    for (int i = 1; i < data.Length; i++)
    {
        if (data[i].Split(',')[0] == cus)
        {
            findcus = true;
            mID = data[i].Split(",")[1];
            
        }
    }
    if (findcus == false)
    {
        Console.WriteLine("Customer not found!");
    }
    else
    {
        
        for (int i = 1; i < data.Length; i++)
        {
            for (int j = 1; j < ord.Length; j++)
            {
                if (mID == ord[j].Split(",")[1])
                {
                    Console.WriteLine("{0,3} {1,9} {2,21} {3,21} {4,7} {5,7} {6,7} {7,14} {8,11} {9,11} {10,11} {11,11} {12,10} {13,10} {14,10}",
            "ID", "MemberID", "TimeReceived", "TimeFufilled", "Option", "Scoops", "Dipped", "WaffleFlavour", "Flavour1", "Flavour2", "Flavour3",
            "Topping1", "Topping2", "Topping3", "Topping4");
                    string[] infos = data[i].Split(",");
                    Customer customer = new Customer(infos[0], Convert.ToInt32(infos[1]), Convert.ToDateTime(infos[2]));
                    string[] info = ord[j].Split(",");
                    Order order = new Order(Convert.ToInt32(info[0]), Convert.ToDateTime(info[2]));
                    Console.WriteLine("{0,3} {1,9} {2,21} {3,21} {4,7} {5,7} {6,7} {7,14} {8,11} {9,11} {10,11} {11,11} {12,10} {13,10} {14,10}",
                        order.Id, customer.MemberID, order.TimeReceived, info[3], info[4], info[5], info[6], info[7], info[8], info[9], info[10], info[11], info[12], info[13], info[14]);
                    
                    break;
                }
            }
            break;
        }
    }
    Console.Write("Enter which order to modify: ");
    int ans = Convert.ToInt32(Console.ReadLine());
    Order modord = new Order();
    modord.ModifyIceCream(ans);
}

//option 7
void ProcessOrder()
{
    if (GoldQueue.Count > 0)
    {
        Order currentorder = GoldQueue.Dequeue();
        double current_order_total = currentorder.CalculateTotal();
        Console.WriteLine("Ice Creams in the Order:");
        foreach (IceCream iceCream in currentorder.IceCreamList)
        {
            Console.WriteLine(iceCream.ToString());
        }
        foreach (var customer in customerlist)
        {
            if (Convert.ToInt32(currentorder.Id) == customer.MemberID)
            {
                Console.WriteLine($"Membership: {customer.Rewards.Tier} Points: {customer.Rewards.Points}");
                if (customer.Dob.Date == DateTime.Now.Date)
                {
                    current_order_total = 0.0;
                }
            }
            break;
        }
    }
    else if (OrdQueue.Count == 0)
    {
        Console.WriteLine("No more orders in queue.");
    }
    else
    {
        Order currentorder = OrdQueue.Dequeue();
        double current_order_total = currentorder.CalculateTotal();
        Console.WriteLine("Ice Creams in the Order:");
        foreach (IceCream iceCream in currentorder.IceCreamList)
        {
            Console.WriteLine(iceCream.ToString());
        }
        foreach (var customer in customerlist)
        {
            if (Convert.ToInt32(currentorder.Id) == customer.MemberID)
            {
                Console.WriteLine($"Membership: {customer.Rewards.Tier} Points: {customer.Rewards.Points}");
                if (customer.Dob.Date == DateTime.Now.Date)
                {
                    current_order_total = 0.0;
                }
                if (customer.Rewards.PunchCard >= 10)
                {
                    current_order_total = 0.00;
                    customer.Rewards.PunchCard = 0;
                }
                foreach (IceCream iceCream in currentorder.IceCreamList)
                {
                    customer.Rewards.PunchCard++;
                }
                if (customer.Rewards.Points > 0)
                {
                    if (customer.Rewards.Tier == "Silver" || customer.Rewards.Tier == "Gold")
                    {
                        Console.Write("Enter points to use: ");
                        int pointsToUse = Convert.ToInt32(Console.ReadLine());
                        if (pointsToUse <= customer.Rewards.Points)
                        {
                            current_order_total -= pointsToUse;
                            customer.Rewards.Points -= pointsToUse;
                        }
                    }
                }
            }
            break;
        }
        Console.WriteLine($"Final Total Bill Amount: ${current_order_total}");
        Console.WriteLine("Press any key to make payment...");
        Console.ReadKey();
        currentorder.TimeFulfilled = DateTime.Now;
    }
}
//option 7 stuff

for (int i = 1; i < data.Length; i++)
{
    string[] customer_info = data[i].Split(",");
    PointCard pointCard = new PointCard(Convert.ToInt32(customer_info[4]),
        Convert.ToInt32(customer_info[5]));
    Customer customer = new Customer(customer_info[0], Convert.ToInt32(customer_info[1]),
                    Convert.ToDateTime(customer_info[2]));
    customer.Rewards = pointCard;
    customer.Rewards.Tier = customer_info[3];
    customerlist.Add(customer);

}

//Check whether user input string is all alphabets
bool IsAlpha(string n)
{
    foreach (char c in n)
    {
        if (char.IsLetter(c))
        {
            return true;
        }
    }
    return false;
}

//Main program loop
while (true)
{
    data = File.ReadAllLines("customers.csv");
    ord = File.ReadAllLines("orders.csv");
    flav = File.ReadAllLines("flavours.csv");
    top = File.ReadAllLines("toppings.csv");

    DisplayMenu();

    Console.Write("Enter option: ");
    string option = Console.ReadLine();

    if (option == "0")
    {
        break;
    }
    //Shane
    else if (option == "1")
    {
        DisplayCustomers();
    }
    //Wei Qin
    else if (option == "2")
    {
        DisplayOrders();
    }
    //Shane
    else if (option == "3")
    {
        RegisterCus();
    }
    //Shane
    else if (option == "4")
    {
        CusOrder();
    }
    //Wei Qin
    else if (option == "5")
    {
        DisplayCustomers();
        DisplayOrdDetails();
    }
    //Wei Qin
    else if (option == "6")
    {
        ModifyOrder();
        
    }
    //Shane
    else if (option == "7")
    {
        ProcessOrder();
    }
    //Wei Qin
    else if (option == "8")
    {

    }
    else
    {
        Console.WriteLine("Invalid option! Please enter again.");
        continue;
    }
}

