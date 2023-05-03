
namespace linqproduct
{
    class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        static void Seeddata(List<Product> product)
        {
            product.Add(new Product { ProductId = "P001", ProductName = "Laptop", Brand = "Dell", Quantity = 5, Price = 35000 });
            product.Add(new Product { ProductId = "P002", ProductName = "Camera", Brand = "Canon", Quantity = 8, Price = 28500 });
            product.Add(new Product { ProductId = "P003", ProductName = "Tablet", Brand = "Lenovo", Quantity = 4, Price = 15000 });
            product.Add(new Product { ProductId = "P004", ProductName = "Mobile", Brand = "Apple", Quantity = 9, Price = 65000 });
            product.Add(new Product { ProductId = "P005", ProductName = "Earphones", Brand = "Boat", Quantity = 2, Price = 1500 });
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Product> product = new List<Product>();
                Seeddata(product);
                Console.WriteLine("Product Name with Price greater than 20000 less than 40000");
                var query = from x in product where x.Price >= 20000 && x.Price <= 40000 select x;
                foreach (var p in query)
                {
                    Console.WriteLine($"{p.ProductName}");
                }

                Console.WriteLine("Product name contains a");
                var res = product.Where(x => x.ProductName.Contains("a")).ToList();
                foreach (var item in res)
                {
                    Console.WriteLine($"{item.ProductId} {item.ProductName} {item.Brand} {item.Quantity} {item.Price}");
                }

                Console.WriteLine("Alphabetical order based product name");
                var res1 = product.OrderBy(x => x.ProductName);
                foreach (var item in res1)
                {
                    Console.WriteLine($"{item.ProductId} {item.ProductName} {item.Brand} {item.Quantity} {item.Price}");
                }

                Console.WriteLine("product with Highest price");
                var res2 = product.Where(c => c.Price == product.Max(p => p.Price)).FirstOrDefault();
                Console.WriteLine($"{res2.ProductId} {res2.ProductName} {res2.Brand} {res2.Quantity} {res2.Price}");

                Console.WriteLine("Check whether id P003 is exist or not");
                var res3 = product.Any(p => p.ProductId == "P003");
                Console.WriteLine(res3);
            }
        }
    }
}