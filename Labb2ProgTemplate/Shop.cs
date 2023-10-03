namespace Labb2ProgTemplate
{
    public class Shop
    {
        private Customer CurrentCustomer { get; set; }

        private List<Product> Products { get; set; }

        public Shop()
        {
            Products = new List<Product>()
            {
                new Product(){Name = "Banan", Price = 10.0},
                new Product(){Name = "Snigel", Price = 25.99},
                new Product(){Name = "Kräfta", Price = 86.0}

            };
        }

        public void MainMenu()
        {
            Console.WriteLine("Välkommen till min butik!");
            
        }

        private void Login()
        {
            
        }

        private void Register()
        {
            
        }

        private void ShopMenu() 
        {
            
        }

        private void ViewCart()
        {
            
        }

        private void Checkout()
        {
            
        }
    }
}
