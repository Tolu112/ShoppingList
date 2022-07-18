
using ShoppingLab_;
//Dictionary with store items
Dictionary<string, decimal> Inventory = new Dictionary<string, decimal>
{
    ["T-Shirt"] = 9.99m,
    ["Wallet"] = 19.99m,
    ["Belt"] = 7.99m,
    ["Jewelry"] = 50.99m,
    ["Hat"] = 14.99m,
    ["Sunglasses"] = 29.99m,
    ["Shoes"] = 49.99m,
    ["Socks"] = 5.99m,

};
//MAIN PROGRAM
int itemNumber = 0;
string itemName = " ";
decimal total = 0;
List<string> Cart = new List<string> ();

//Program loop
bool runProgram = true;
while (runProgram)
{
   //Display Inventory
   ShoppingList.ListInventory(Inventory);

   //Get user's items and add to cart
   ShoppingList.AddUserChoiceToCart("Please enter the name or number of the item you'd like to buy: ", itemName, itemNumber, Cart, Inventory);

   //Ask user to continue
   Console.Clear();
   runProgram = Validator.Validator.GetContinue("\nWould you like to buy anymore items?", "y", "n");
   Console.Clear();

}
//End of shopping experience, display receipt 
Console.Clear();
Console.WriteLine("\nThank you for shopping with us. Here is your receipt: \n");

//Display header
Console.WriteLine(string.Format("{0,-15}{1,15}", "Item", "Cost"));
Console.WriteLine(string.Format("{0,-15}{1,15}", "=======", "======="));

//Display items, prices, and total
ShoppingList.DisplayReceipt(total, Cart, Inventory);






