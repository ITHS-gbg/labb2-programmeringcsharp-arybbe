namespace Labb2ProgTemplate
{
    public class Shop
    {
        private Customer CurrentCustomer { get; set; }

        private List<Product> Products { get; set; }

        public Dictionary<string, string> Customers { get; set; }

        public Shop()
        {
            Products?.AddRange(new List<Product>
            {
                new (){Name = "Banan", Price = 10.0},
                new (){Name = "Snigel", Price = 25.99},
                new (){Name = "Kräfta", Price = 86.0}

            });

            Customers = new Dictionary<string, string>
            {
                { "Knatte", "123" },
                { "Fnatte", "321" },
                { "Tjatte", "213" }
            };
        }

        public void MainMenu()
        {
            while (true)
            {
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
                            Console.Write("Ange användarnamn: ");
                            string usernameLogin = Console.ReadLine();
                            Console.Write("Ange lösenord: ");
                            string passwordLogin = Console.ReadLine();
                            var currentCustomer = Login(usernameLogin, passwordLogin);

                            if (currentCustomer != null)
                            {
                                Console.WriteLine($"Inloggad som kund: {currentCustomer.Value}");

                                break;
                            }
                            
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

        private KeyValuePair<string, string>? Login(string name, string password)
        {
            foreach (var customer in Customers)
            {
                if (Customers.ContainsKey(name) && Customers.ContainsValue(password))
                {
                    return customer;
                }
            }

            Console.WriteLine("Fel användarnamn eller lösenord!");
            return null;
        }

        private void Register(string name, string password)
        {
            CurrentCustomer = new Customer(name, password);
            Customers.Add(name, password);
            Console.WriteLine("Du är registrerad!");
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
