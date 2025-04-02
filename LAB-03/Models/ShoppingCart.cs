namespace LAB_03.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(CartItem item)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        // Method to get all items in the cart
        public List<CartItem> GetItems()
        {
            return Items;
        }

        // Method to clear the cart
        public void ClearCart()
        {
            Items.Clear();
        }

        // Method to update the quantity of a specific item
        public void UpdateItemQuantity(int productId, int quantity)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity = quantity;
                if (existingItem.Quantity <= 0)
                {
                    RemoveItem(productId);
                }
            }
        }

        // Method to get the total price of the items in the cart
        public decimal GetTotalPrice()
        {
            return Items.Sum(i => i.Quantity * i.Price);
        }

        public string FormatPriceToVND(decimal price)
        {
            return string.Format("{0:#,##0}", price);
        }
    }
}
