// See https://aka.ms/new-console-template for more information

namespace FirstApp
{
    enum ProductCategory
    {
        Electronics,
        Clothing,
        Food
    }
    struct Product 
    {
        public string Name;
        public decimal Price;
        // public string Category;
        public ProductCategory Category;

        public Product(string name, decimal price, ProductCategory category) 
        {
            Name = name;
            Price = price;
            Category = category;
        }

        public decimal ProductInDolar(double rate) 
        {
            Price = Price * (decimal)rate;
            return Price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product("Laptop", 1000, ProductCategory.Electronics);
            System.Console.WriteLine(p.Name);
            System.Console.WriteLine(p.Price);
            System.Console.WriteLine(p.Category);

            var pInDolar = p.ProductInDolar(5.5849);
            System.Console.WriteLine(pInDolar);
        }

    }
}
