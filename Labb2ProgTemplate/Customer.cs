using System.Text;

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

        public override string ToString()
        {
            string output = string.Empty;
            output += $"Kundvagn för {Name}: \n";

            var productCount = new Dictionary<Product, int>();

            foreach (var product in Cart)
            {


                if (productCount.ContainsKey(product))
                {
                    productCount[product] += 1;
                }
                else
                {
                    productCount[product] = 1;
                }
            }

            foreach (var kvp in productCount)
            {
                var product = kvp.Key;
                var count = kvp.Value;
                double subTotal = product.Price * count;


                output += $"{product.Name} {count}st {product.Price}kr/st = {subTotal}kr\n";
            }

            output += $"Totalt: {CartTotal()}kr\n";

            return output;
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
        
        public double CartTotal()
        {
            var totalPrice = 0.0;

            foreach (var product in Cart)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }

    }
}
