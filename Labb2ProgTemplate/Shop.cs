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
                new() { Name = "Snigel", Price = 25.0 },
                new() { Name = "Kräfta", Price = 85.0 }
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
                        Console.Clear();
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
                                    CurrentCustomer = Login(usernameLogin, passwordLogin);

                                    if (CurrentCustomer != null)
                                    {
                                        while (true)
                                        {
                                            Console.Clear();
                                            Console.WriteLine($"Inloggad som: {CurrentCustomer.Name}");
                                            Console.WriteLine("Välj att handla, gå till kundvagn eller gå till kassan!");
                                            Console.WriteLine("1. Handla");
                                            Console.WriteLine("2. Kundvagn");
                                            Console.WriteLine("3. Gå till Kassan");
                                            Console.WriteLine("4. Logga ut");

                                            string customerChoice = Console.ReadLine();

                                            if (customerChoice == "1")
                                            {
                                                ShopMenu(CurrentCustomer);
                                            }

                                            if (customerChoice == "2")
                                            {
                                                Console.Clear();
                                                ViewCart(CurrentCustomer);
                                                Console.WriteLine("Tryck valfri knapp för att gå vidare.");
                                                RemoveProductsMenu(CurrentCustomer);
                                                
                                            }

                                            if (customerChoice == "3")
                                            {
                                                Console.Clear();
                                                Checkout(CurrentCustomer);
                                                return;
                                            }

                                            if (customerChoice == "4")
                                            {
                                                break;
                                            }
                                        }
                                        

                                    }
                                    break;
                                }
                            }

                            if (!customerFound)
                            {
                                Console.WriteLine("Användare finns inte. Försök igen eller registrera ny kund!");
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
                Console.Clear();
                Console.WriteLine("Välj vilken produkt du vill lägga till i kundvagnen eller tryck enter för att gå vidare..");
                Console.WriteLine($"1. {Products[0].Name}: {Products[0].Price}kr / st");
                Console.WriteLine($"2. {Products[1].Name}: {Products[1].Price}kr / st");
                Console.WriteLine($"3. {Products[2].Name}: {Products[2].Price}kr / st");

                string productChoice = Console.ReadLine();
                
                if (productChoice == "")
                {
                    break;
                }

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
                        Console.WriteLine("Välj produkt eller tryck enter..");
                        break;
                }

                
            }
            
        }

        private void ViewCart(Customer customer)
        {
            Console.WriteLine(customer);
        }

        private void Checkout(Customer customer)
        {
            Console.WriteLine(customer);
            Console.WriteLine("Betalar och avslutar!");
        }


        private void RemoveProductsMenu(Customer customer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Välj vilken produkt du vill ta bort i kundvagnen eller tryck enter för att gå vidare..");
                ViewCart(customer);

                string productChoice = Console.ReadLine();

                if (productChoice == "")
                {
                    break;
                }

                switch (productChoice)
                {
                    case "Banan":
                        customer.RemoveFromCart(Products[0]);
                        break;
                    case "Snigel":
                        customer.RemoveFromCart(Products[1]);
                        break;
                    case "Kräfta":
                        customer.RemoveFromCart(Products[2]);
                        break;
                    default:
                        Console.WriteLine("Välj produkt eller tryck enter..");
                        break;
                }


            }
        }
    }
}
