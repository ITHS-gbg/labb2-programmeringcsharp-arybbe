namespace Labb2ProgTemplate
{
    public class Customer
    {
        public string Name { get; private set; }

        private string Password { get; set; }

        private List<Product> _cart;
        public List<Product> Cart { get { return _cart; } }

        public Customer(string name, string password)
        {
            Name = name;
            Password = password;
            _cart = new List<Product>();
        }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }

        public void AddToCart(Product product)
        {
            Cart.Add(product);
        }

        public void RemoveFromCart(Product product) 
        {
            Cart.Remove(product);
        }
        
        public double CartTotal(Customer customer)
        {
            var totalPrice = 0.0;

            foreach (var product in customer.Cart)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
