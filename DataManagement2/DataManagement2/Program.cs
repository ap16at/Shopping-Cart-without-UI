// Assignment 2 - ShoppingCart
// Due: 2-10-21
// Written by: Andrew Perez-Napan

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement2
{
    class ShoppingCart
    {
        public List<Product> Cart;
        public double Price;

        public ShoppingCart()
        {
            Cart = new List<Product>();
        }
        public void AddToCart(Product p)
        {
            Cart.Add(p);
        }
        public void RemoveFromCart(Product p)
        {

            Cart.Remove(p);
        }
        public static void Print(ProductByQuantity p, int pos)
        {
            Console.WriteLine("| {0, -21} | ${1, -17} | {2, -18} | {3, -18} | {4, -25} |", pos + " - " + p.Name, string.Format("{0:0.00}", p.Price), p.Units, p.Id, p.Description);
        }
        public static void Print(ProductByWeight p, int pos)
        {
            Console.WriteLine("| {0, -21} | ${1, -17} | {2, -18} | {3, -18} | {4, -25} |", pos + " - " + p.Name, string.Format("{0:0.00}", p.Price), p.Ounces, p.Id, p.Description);
        }
        public void Receipt()
        {
            double subtotal = 0;
            double tax = 0;
            double total = 0;

            Console.WriteLine("\n| {0, 21} | {1, 18} | {2, 18} | {3, 18} | {4, 25} |", "NAME", "PRICE", "AMMOUNT", "ID", "DESCRIPTION");

            for (int j = 0; j < Cart.Count(); j++)
            {

                if (Cart[j] is ProductByQuantity)
                {
                    ShoppingCart.Print(((ProductByQuantity)Cart[j]), j + 1);
                    var pos1 = ((ProductByQuantity)Cart[j]);
                    subtotal += pos1.Price;
                }
                else if (Cart[j] is ProductByWeight)
                {
                    ShoppingCart.Print(((ProductByWeight)Cart[j]), j + 1);
                    var pos1 = ((ProductByWeight)Cart[j]);
                    subtotal += pos1.Price;
                }

            }

            tax = 0.07 * subtotal;
            total = subtotal + tax;

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("{0, 116}", "Subtotal: $" + string.Format("{0:0.00}", subtotal));
            Console.WriteLine("{0, 116}", "Tax: $" + string.Format("{0:0.00}", tax));
            Console.WriteLine("{0, 116}", "TOTAL: $" + string.Format("{0:0.00}", total));
        }
    }

    class Product
    {
        public Product(){}
        public static void Print(Product p, int pos)
        {
            Console.WriteLine("{0, -23} | ${1, -17} | {2, -18} | {3, -25} |", pos + " - " + p.Name, string.Format("{0:0.00}", p.Price), p.Id, p.Description);
        }
        private double price;
        public virtual double Price
        {
            get { return price; }
            set { price = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }

    class ProductByQuantity : Product
    {
        public ProductByQuantity(string name, double unitP, int id, string des)
        {
            Name = name;
            UnitPrice = unitP;
            Units = 1;
            Price = UnitPrice * Units;
            Id = id;
            Description = des;
        }
        public ProductByQuantity(string name, double unitP, int unit, int id, string des)
        {
            Name = name;
            UnitPrice = unitP;
            Units = unit;
            Price = UnitPrice * Units;
            Id = id;
            Description = des;
        }
        private double unitPrice;
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        private int units;
        public int Units
        {
            get { return units; }
            set { units = value; }
        }
        private double price;
        public override double Price
        {
            get { return price = UnitPrice * Units; }
            set { price = value; }
        }
    }

    class ProductByWeight : Product
    {
        public ProductByWeight(string name, double ounceP, int id, string des)
        {
            Name = name;
            PricePerOunce = ounceP;
            Ounces = 1;
            Price = PricePerOunce * Ounces;
            Id = id;
            Description = des;
        }
        public ProductByWeight(string name, double ounceP, double ounces, int id, string des)
        {
            Name = name;
            PricePerOunce = ounceP;
            Ounces = ounces;
            Price = PricePerOunce * Ounces;
            Id = id;
            Description = des;
        }
        private double pricePerOunce;
        public double PricePerOunce
        {
            get { return pricePerOunce; }
            set { pricePerOunce = value; }
        }
        private double ounces;
        public double Ounces
        {
            get { return ounces; }
            set { ounces = value; }
        }
        private double price;
        public override double Price
        {
            get { return price = PricePerOunce * Ounces; }
            set { price = value; }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> Inventory = new List<Product>();

            ShoppingCart ShoppingCart = new ShoppingCart();

            ProductByQuantity p1 = new ProductByQuantity("Lightbulb", 1.50, 003, "1 lightbulb");
            ProductByQuantity p2 = new ProductByQuantity("Ketchup", 6.99, 134, "1 Heinz Ketchup bottle");
            ProductByQuantity p3 = new ProductByQuantity("Toilet Paper", 2.49, 034, "1 roll");
            ProductByQuantity p4 = new ProductByQuantity("Paper Towel Roll", 2.99, 048, "1 roll");
            ProductByQuantity p5 = new ProductByQuantity("Toothbrush", 4.99, 890, "1 toothbrush");
            ProductByQuantity p6 = new ProductByQuantity("Coke", 1.99, 340, "1 2-liter bottle");
            ProductByQuantity p7 = new ProductByQuantity("Lays potato chips", 2.99, 897, "1 bag of chips");
            ProductByQuantity p8 = new ProductByQuantity("Spaghetti", 5.99, 321, "1 box of pasta");
            ProductByQuantity p9 = new ProductByQuantity("Can of soup", 6.99, 537, "Chicken noodle");
            ProductByQuantity p10 = new ProductByQuantity("Frying Pan", 17.99, 348, "Non-stick");
            ProductByWeight p11 = new ProductByWeight("Apples", 2.79, 765, "Red apple");
            ProductByWeight p12 = new ProductByWeight("Bannanas", 1.34, 345, "Yellow banana");
            ProductByWeight p13 = new ProductByWeight("Ribeye", 3.50, 090, "Ribeye steak");
            ProductByWeight p14 = new ProductByWeight("Chicken breast", 2.50, 438, "Cage free");
            ProductByWeight p15 = new ProductByWeight("Salmon", 2.35, 568, "Alaskan");
            ProductByWeight p16 = new ProductByWeight("Potatoes", 0.69, 009, "yellow");
            ProductByWeight p17 = new ProductByWeight("Onions", 0.69, 007, "sweet onions");
            ProductByWeight p18 = new ProductByWeight("Avocados", 1.28, 008, "Mexican Hass");
            ProductByWeight p19 = new ProductByWeight("Red Bell Peppers", 0.99, 002, "Organic");
            ProductByWeight p20 = new ProductByWeight("Green Bell Peppers", 0.99, 023, "Organic");

            Inventory.Add(p1);
            Inventory.Add(p2);
            Inventory.Add(p3);
            Inventory.Add(p4);
            Inventory.Add(p5);
            Inventory.Add(p6);
            Inventory.Add(p7);
            Inventory.Add(p8);
            Inventory.Add(p9);
            Inventory.Add(p10);
            Inventory.Add(p11);
            Inventory.Add(p12);
            Inventory.Add(p13);
            Inventory.Add(p14);
            Inventory.Add(p15);
            Inventory.Add(p16);
            Inventory.Add(p17);
            Inventory.Add(p18);
            Inventory.Add(p19);
            Inventory.Add(p20);

            bool loopBreak = true;
            bool inListConditional = true;
            bool cartListConditional = true;

            do
            {

                Console.WriteLine("\n-----------------");
                Console.WriteLine("1. View Inventory");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("0. Exit Program");
                Console.WriteLine("-----------------\n");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {

                    Console.WriteLine("Items in Inverntory:");
                    
                    int currentPage = 1;
                    int items = Inventory.Count();
                    int inPages = items / 5;
                    int lastPageItems = items - ((inPages - 1) * 5);
                    int lastPageStart = ((inPages - 1) * 5) + 1;
                    
                    do
                    {
                        Console.WriteLine("| {0, 21} | {1, 18} | {2, 18} | {3, 25} |", "NAME", "PRICE", "ID", "DESCRIPTION");
                        if (currentPage == inPages)
                        {
                            for (int j = lastPageStart; j < items + 1; j++)
                            {
                                Product.Print(Inventory[j - 1], j);
                            }
                            Console.WriteLine("\np - Previous");
                            Console.WriteLine("e - Exit");
                            Console.WriteLine("s - Select an item by number to add to cart");
                        }
                        else if (currentPage == 1)
                        {
                            for (int j = 1; j < 6; j++)
                            {
                                Product.Print(Inventory[j - 1], j);
                            }
                            Console.WriteLine("\nn - Next");
                            Console.WriteLine("e - Exit");
                            Console.WriteLine("s - Select an item by number to add to cart");
                        }
                        else
                        {
                            for (int j = (currentPage * 5) - 4; j < (currentPage * 5) + 1; j++)
                            {
                                Product.Print(Inventory[j - 1], j);
                            }
                            Console.WriteLine("\np - Previous");
                            Console.WriteLine("n - Next");
                            Console.WriteLine("e - Exit");
                            Console.WriteLine("s - Select an item by number to add to cart");
                        }
                        string setPage = Console.ReadLine();
                        if (setPage == "p" && currentPage > 1)
                        {
                            Console.WriteLine("\n");
                            currentPage--;
                            continue;
                        }
                        else if (setPage == "n" && currentPage < inPages)
                        {
                            Console.WriteLine("\n");
                            currentPage++;
                            continue;
                        }
                        else if(setPage == "e")
                        {
                            break;
                        }
                        else if(setPage == "s")
                        {
                            Console.WriteLine("Enter item number: ");
                            int pos = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n");

                            if (Inventory[pos-1] is ProductByQuantity)
                            {
                                Console.WriteLine("How many Units of this item would you like?");
                                Console.WriteLine("\n");
                                int units = Convert.ToInt32(Console.ReadLine());

                                var pos1 = ((ProductByQuantity)Inventory[pos-1]);

                                ProductByQuantity pTemp = new ProductByQuantity(pos1.Name, pos1.UnitPrice, units, pos1.Id, pos1.Description);

                                ShoppingCart.AddToCart(pTemp);
                            }
                            else if(Inventory[pos-1] is ProductByWeight)
                            {
                                Console.WriteLine("How many Ounces of this item would you like?");
                                Console.WriteLine("\n");
                                double ounces = Convert.ToDouble(Console.ReadLine());

                                var pos1 = ((ProductByWeight)Inventory[pos - 1]);

                                ProductByWeight pTemp = new ProductByWeight(pos1.Name, pos1.PricePerOunce, ounces, pos1.Id, pos1.Description);

                                ShoppingCart.AddToCart(pTemp);
                            }
                        }

                    } while (inListConditional);

                }
                else if(choice == 2)
                {

                    Console.WriteLine("Items in Cart:");
                
                    int currentPage = 1;
                    int items = ShoppingCart.Cart.Count();
                    int itemsTemp = items;
                    int cartPages = 1;

                    for (int i = 0; i < items; i++)
                    {
                        itemsTemp -= 5;
                        if (itemsTemp > 0)
                            cartPages++;
                        else
                            break;
                    }

                    int lastPageItems = items - ((cartPages - 1) * 5);
                    int lastPageStart = ((cartPages - 1) * 5) + 1;

                    if(cartPages > 1)
                    {
                        do
                        {
                            if (items == 0)
                            {
                                Console.WriteLine("Cart is currently empty.");
                                break;
                            }

                            Console.WriteLine("| {0, 21} | {1, 18} | {2, 18} | {3, 18} | {4, 25} |", "NAME", "PRICE", "AMMOUNT", "ID", "DESCRIPTION");

                            if (currentPage == cartPages)
                            {
                                for (int j = lastPageStart; j < items + 1; j++)
                                {
                                    if (ShoppingCart.Cart[j - 1] is ProductByQuantity)
                                    {
                                        ShoppingCart.Print(((ProductByQuantity)ShoppingCart.Cart[j - 1]), j);
                                    }
                                    else if (ShoppingCart.Cart[j - 1] is ProductByWeight)
                                    {
                                        ShoppingCart.Print(((ProductByWeight)ShoppingCart.Cart[j - 1]), j);
                                    }
                                }
                                Console.WriteLine("\np - Previous");
                                Console.WriteLine("e - Exit");
                                Console.WriteLine("s- Select an item by number to remove from cart");
                            }
                            else if (currentPage == 1)
                            {
                                for (int j = 1; j < 6; j++)
                                {
                                    if (ShoppingCart.Cart[j - 1] is ProductByQuantity)
                                    {
                                        ShoppingCart.Print(((ProductByQuantity)ShoppingCart.Cart[j - 1]), j);
                                    }
                                    else if (ShoppingCart.Cart[j - 1] is ProductByWeight)
                                    {
                                        ShoppingCart.Print(((ProductByWeight)ShoppingCart.Cart[j - 1]), j);
                                    }
                                }
                                Console.WriteLine("\nn - Next");
                                Console.WriteLine("e - Exit");
                                Console.WriteLine("s- Select an item by number to remove from cart");
                            }
                            else
                            {
                                for (int j = (currentPage * 5) - 4; j < (currentPage * 5) + 1; j++)
                                {
                                    if (ShoppingCart.Cart[j - 1] is ProductByQuantity)
                                    {
                                        ShoppingCart.Print(((ProductByQuantity)ShoppingCart.Cart[j - 1]), j);
                                    }
                                    else if (ShoppingCart.Cart[j - 1] is ProductByWeight)
                                    {
                                        ShoppingCart.Print(((ProductByWeight)ShoppingCart.Cart[j - 1]), j);
                                    }
                                }
                                Console.WriteLine("\np - Previous");
                                Console.WriteLine("n - Next");
                                Console.WriteLine("e - Exit");
                                Console.WriteLine("s -Select an item by number to remove from cart");
                            }
                            string setPage = Console.ReadLine();
                            if (setPage == "p" && currentPage > 1)
                            {
                                Console.WriteLine("\n");
                                currentPage--;
                                continue;
                            }
                            else if (setPage == "n" && currentPage < cartPages)
                            {
                                Console.WriteLine("\n");
                                currentPage++;
                                continue;
                            }
                            else if (setPage == "e")
                            {
                                break;
                            }
                            else if (setPage == "s")
                            {
                                Console.WriteLine("Enter item number: ");
                                int pos = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n");

                                if (Inventory[pos - 1] is ProductByQuantity)
                                {
                                    Console.WriteLine("How many Units of this item would you like to remove?");
                                    int units = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("\n");

                                    var pos1 = ((ProductByQuantity)Inventory[pos - 1]);
                                    int newUnits = pos1.Units - units;

                                    if (pos1.Units == units)
                                    {
                                        ShoppingCart.RemoveFromCart(pos1);
                                    }
                                    else if (units > pos1.Units || units < 0)
                                    {
                                        Console.WriteLine("Unit amount is Invalid.");
                                    }
                                    else
                                    {
                                        ShoppingCart.RemoveFromCart(pos1);

                                        ProductByQuantity pTemp = new ProductByQuantity(pos1.Name, pos1.Price, newUnits, pos1.Id, pos1.Description);
                                        ShoppingCart.AddToCart(pTemp);
                                    }


                                }
                                else if (Inventory[pos - 1] is ProductByWeight)
                                {
                                    Console.WriteLine("How many Ounces of this item would you like to remove?");
                                    double ounces = Convert.ToDouble(Console.ReadLine());
                                    Console.WriteLine("\n");

                                    var pos1 = ((ProductByWeight)Inventory[pos - 1]);
                                    double newOunces = pos1.Ounces - ounces;

                                    if (pos1.Ounces == ounces)
                                    {
                                        ShoppingCart.RemoveFromCart(pos1);
                                    }
                                    else if (ounces > pos1.Ounces || ounces < 0)
                                    {
                                        Console.WriteLine("Unit amount is Invalid.");
                                    }
                                    else
                                    {
                                        ShoppingCart.RemoveFromCart(pos1);

                                        ProductByWeight pTemp = new ProductByWeight(pos1.Name, pos1.Price, newOunces, pos1.Id, pos1.Description);
                                        ShoppingCart.AddToCart(pTemp);
                                    }
                                }
                            }

                        } while (cartListConditional);

                    }
                    else
                    {
                        Console.WriteLine("| {0, 21} | {1, 18} | {2, 18} | {3, 18} | {4, 25} |", "NAME", "PRICE", "AMMOUNT", "ID", "DESCRIPTION");
                        for (int j = 1; j < items + 1; j++)
                        {

                            if (ShoppingCart.Cart[j - 1] is ProductByQuantity)
                            {
                                ShoppingCart.Print(((ProductByQuantity)ShoppingCart.Cart[j - 1]), j);
                            }
                            else if (ShoppingCart.Cart[j - 1] is ProductByWeight)
                            {
                                ShoppingCart.Print(((ProductByWeight)ShoppingCart.Cart[j - 1]), j);
                            }

                        }

                        Console.WriteLine("\ne - Exit");
                        Console.WriteLine("s -Select an item by number to remove from cart");
                        string setPage = Console.ReadLine();

                        if (setPage == "e")
                        {
                            continue; ;
                        }
                        else if (setPage == "s")
                        {
                            Console.WriteLine("Enter item number: ");
                            int pos = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\n");

                            if (ShoppingCart.Cart[pos - 1] is ProductByQuantity)
                            {
                                Console.WriteLine("How many Units of this item would you like to remove?");
                                int units = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n");

                                var pos1 = ((ProductByQuantity)ShoppingCart.Cart[pos - 1]);
                                int newUnits = pos1.Units - units;

                                if (pos1.Units == units)
                                {
                                    ShoppingCart.RemoveFromCart(pos1);
                                }
                                else if (units > pos1.Units || units < 0)
                                {
                                    Console.WriteLine("Unit amount is Invalid.");
                                }
                                else
                                {
                                    ShoppingCart.RemoveFromCart(pos1);

                                    ProductByQuantity pTemp = new ProductByQuantity(pos1.Name, pos1.UnitPrice, newUnits, pos1.Id, pos1.Description);
                                    ShoppingCart.AddToCart(pTemp);
                                }


                            }
                            else if (ShoppingCart.Cart[pos - 1] is ProductByWeight)
                            {
                                Console.WriteLine("How many Ounces of this item would you like to remove?");
                                double ounces = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine("\n");

                                var pos1 = ((ProductByWeight)ShoppingCart.Cart[pos - 1]);
                                double newOunces = pos1.Ounces - ounces;

                                if (pos1.Ounces == ounces)
                                {
                                    ShoppingCart.RemoveFromCart(pos1);
                                }
                                else if (ounces > pos1.Ounces || ounces < 0)
                                {
                                    Console.WriteLine("Unit amount is Invalid.");
                                }
                                else
                                {
                                    ShoppingCart.RemoveFromCart(pos1);

                                    ProductByWeight pTemp = new ProductByWeight(pos1.Name, pos1.PricePerOunce, newOunces, pos1.Id, pos1.Description);
                                    ShoppingCart.AddToCart(pTemp);
                                }
                            }

                        }
                    }

                }
                else if(choice == 3)
                {
                    if(ShoppingCart.Cart.Count() > 0)
                        ShoppingCart.Receipt();

                    continue;
                }
                else if(choice == 0)
                {
                    loopBreak = false;
                }
                else
                {

                    Console.WriteLine("Input invalid. Please try again.");
                    continue;

                }

            } while (loopBreak);

        }
    }
}
