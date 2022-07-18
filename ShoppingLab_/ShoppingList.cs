using System;
namespace ShoppingLab_
{
    public class ShoppingList 
    {
        //Properties
        public string ItemName { get; set; }
        public int ItemNumber { get; set; }
        public decimal Total { get; set; }

        //Constructor
        public ShoppingList(string _itemname, int _itemnumber, decimal _total)
        {
            ItemName = _itemname;
            ItemNumber = _itemnumber;
            Total = _total;

        }

        //Methods

        //Method to display Inventory List
        public static void ListInventory(Dictionary<string, decimal> inventory)
        {
            int index = 0;
            Console.WriteLine(string.Format("{0,-5}{1,12}{2,14}", "Item#", "Name", "Price"));
            Console.WriteLine(string.Format("{0,-5}{1,16}{2,10}", "=====", "===========", "====="));
            foreach (KeyValuePair<string, decimal> kvp in inventory)
            {
                Console.WriteLine(string.Format("{0,-11}{1,-12}{2,8}", $"{index +1}.", $"{kvp.Key}", $"{kvp.Value}"));
                index++;
            }
        }


        //Method  to get user choice and add to cart
        public static bool AddUserChoiceToCart (string message, string ItemName, int ItemNumber, List<string> cart, Dictionary<string, decimal> inventory)
        {
            bool result = true;
            while (true)
            {
                //default value

                ////Get item name or number from user
                Console.Write($"\n{message}");
                ItemName = Console.ReadLine();

                //If user enters item name
                if (inventory.ContainsKey(ItemName))
                {

                    Console.Clear();
                    cart.Add(ItemName);
                    result = false;
                    break;
                }
                else if (int.TryParse(ItemName, out ItemNumber) && Validator.Validator.InRange(ItemNumber, 1, 8))
                {

                    Console.Clear();
                    cart.Add(inventory.Keys.ElementAt(ItemNumber - 1));
                    result = false;
                    break;
                }
                else
                {

                    Console.WriteLine("Item not in stock. Please try again");
                    continue;
                }
            }
            return result;
        }

        //Method to display receipt
        public static decimal DisplayReceipt(decimal Total, List<string> cart, Dictionary<string, decimal> inventory)
        {

            //Display cart
            foreach (string item in cart.OrderByDescending(i => inventory[i])) //Order by highest price
            {

                Console.WriteLine(string.Format("{0,-15}{1,15}", $"{item}", $"{inventory[item]}"));
                //Calculate total
                Total += inventory[item];
            }

            //Display total
            Console.WriteLine(string.Format("{0,-15}{1,15}", "========", "======="));
            Console.WriteLine(string.Format("{0,-15}{1,15}", "Total", Total));
            return Total;
        }
    }

}
