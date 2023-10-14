namespace Labb2ProgTemplate
{
    public class Shop
    {
        private Customer CurrentCustomer { get; set; }

        private List<Product> Products { get; set; }

        public Dictionary<string, Customer> Customers { get; set; } = new();

        public Shop()
        {
            Products = new List<Product>()
            {
                new() { Name = "Banan", Price = 10.0 },
                new() { Name = "Snigel", Price = 25.99 },
                new() { Name = "Kräfta", Price = 86.0 }
            };

            Customers.Add("Knatte", new Customer("Knatte", "123"));
            Customers.Add("Fnatte", new Customer("Fnatte", "321"));
            Customers.Add("Tjatte", new Customer("Tjatte", "213"));
        }

        


        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välkommen till min butik!");
                Console.WriteLine("1. Registrera ny kund");
                Console.WriteLine("2. Logga in");
                Console.WriteLine("3. Avsluta program");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Ange användarnamn: ");
                        string usernameRegistered = Console.ReadLine();
                        Console.Write("Ange lösenord: ");
                        string passwordRegistered = Console.ReadLine();
                        Register(usernameRegistered, passwordRegistered);
                        break;
                    case "2":
                        while (true)
                        {
                            Console.Clear();
                            Console.Write("Ange användarnamn: ");
                            string usernameLogin = Console.ReadLine();
                            Console.Write("Ange lösenord: ");
                            string passwordLogin = Console.ReadLine();

                            var customerFound = false;

                            foreach (var customersValue in Customers.Values)
                            {
                                if (customersValue.Name == usernameLogin)
                                {
                                    customerFound = true;
                                    var currentCustomer = Login(usernameLogin, passwordLogin);

                                    if (currentCustomer != null)
                                    {
                                        Console.WriteLine($"Inloggad som: {currentCustomer.Name}");
                                        ShopMenu(currentCustomer);
                                        //Implementera shop meny här

                                    }
                                    break;
                                }
                            }

                            if (!customerFound)
                            {
                                Console.WriteLine("Användare finns inte. Försök igen!");
                                Thread.Sleep(2000);
                            }
                            break;
                            
                            
                        }
                        break;
                    case "3":
                        Console.WriteLine("Avslutar!");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val! Försök igen!");
                        break;
                }

            }

        }

        private Customer Login(string name, string password)
        {
            if (Customers.TryGetValue(name, out Customer customer))
            {
                if (customer.CheckPassword(password))
                {
                    return customer;
                }
            }

            Console.WriteLine("Fel lösenord. Försök igen!");
            Thread.Sleep(2000);
            return null;
        }

        private void Register(string name, string password)
        {
            if (Customers.ContainsKey(name))
            {
                Console.WriteLine("Användarnamn finns redan!");
            }
            else
            {
                var customer = new Customer(name, password);
                Customers.Add(name, customer);
                Console.WriteLine("Kund registrerad!");
                Thread.Sleep(2000);
            }
        }

        private void ShopMenu(Customer customer)
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("Välj vilken produkt du vill lägga till i kundvagnen eller tryck enter för att gå vidare..");
                Console.WriteLine($"1. {Products[0].Name}: {Products[0].Price}kr / st");
                Console.WriteLine($"2. {Products[1].Name}: {Products[1].Price}kr / st");
                Console.WriteLine($"3. {Products[2].Name}: {Products[2].Price}kr / st");

                string toCartToCheckOutOrKeepBuying = "";
                string productChoice = Console.ReadLine();

                switch (productChoice)
                {
                    case "1":
                        customer.AddToCart(Products[0]);
                        break;
                    case "2":
                        customer.AddToCart(Products[1]);
                        break;
                    case "3":
                        customer.AddToCart(Products[2]);
                        break;
                    default:
                        Console.WriteLine("Du valde ingen produkt!");
                        break;
                }

                if (productChoice == "")
                {
                    
                }

                foreach (var product in customer.Cart)
                {
                    Console.WriteLine(product.Name);
                }
            }
            
        }

        private void ViewCart(Customer customer)
        {
            customer.Cart.Sort();
            double totalPrice;
            foreach (var product in customer.Cart)
            {
                var amountOfProducts = product;  

                Console.WriteLine($"{product.Name} ");
            }
        }

        private void Checkout(Customer customer)
        {

        }

    }
}
