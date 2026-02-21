namespace InventoryApp.Views
{
    public class InventoryView
    {
        private InventoryApp.Services.InventoryService _service =
            new InventoryApp.Services.InventoryService();

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- Inventory Menu ---");
                Console.WriteLine("1. View Inventory\n2. Update Stock\n3. Reset Inventory\n4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayInventory();
                        break;

                    case "2":
                        PromptUpdate();
                        break;

                    case "3":
                        _service.ResetInventory();
                        Console.WriteLine("Inventory Reset!");
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void DisplayInventory()
        {
            var data = _service.GetInventory();

            for (int i = 0; i < data.GetLength(1); i++)
            {
                Console.WriteLine($"{i + 1}. {data[0, i]}: {data[1, i]}");
            }
        }

        private void PromptUpdate()
        {
            Console.Write("Enter product number (1-3): ");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                index -= 1;

                if (index >= 0 && index < 3)
                {
                    Console.Write("Enter new quantity: ");
                    string qty = Console.ReadLine();
                    _service.UpdateStock(index, qty);
                    Console.WriteLine("Stock updated!");
                }
                else
                {
                    Console.WriteLine("Invalid product number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
