using System;

    public class SaleForbiddenException : Exception
    {
        public SaleForbiddenException(string message) : base(message)
        {
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }

    public class Customer
    {
        public int Age { get; set; }
    }

    public class Seller
    {
        public void Sell(Product product, Customer customer)
        {
            if (product.Name == "алкоголь" && customer.Age < 18)
            {
                throw new SaleForbiddenException("Продажа запрещена!");
            }
            else
            {
                Console.WriteLine("Товар продан");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product() { Name = "алкоголь" };
            Customer customer = new Customer() { Age = 17 };
            Seller seller = new Seller();

            try
            {
                seller.Sell(product, customer);
            }
            catch (SaleForbiddenException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }