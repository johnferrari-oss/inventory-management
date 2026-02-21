namespace InventoryApp.Services
{
    public class InventoryService
    {
        private string[,] products = {
            { "Apples", "Milk", "Bread" },
            { "10", "5", "20" }
        };

        private string[] initialStock = { "10", "5", "20" };

        public string[,] GetInventory() => products;

        public void UpdateStock(int productIndex, string newQuantity)
        {
            products[1, productIndex] = newQuantity;
        }

        public void ResetInventory()
        {
            for (int i = 0; i < initialStock.Length; i++)
            {
                products[1, i] = initialStock[i];
            }
        }
    }
}
