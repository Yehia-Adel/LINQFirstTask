using LINQ.Models;

namespace LINQFirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Get all products from the "Seafood" category. Print each
            //product's name and price.

            List<Product> products = new List<Product>();
            var seafoodProducts = products.Where(p => p.Category == "Seafood");

            foreach (var product in seafoodProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}\nProduct Price: {product.UnitPrice}");
            }

            //2.Get a list of only the product names from ProductList.Print
            //each name.

            var productNames = products.Select(p => p.ProductName).ToList();
            foreach (var name in productNames)
            {
                Console.WriteLine($"Product Name: {name}");
            }

            //3.Sort all products by UnitPrice(ascending). Print each
            //product's name and price.

            var sortedProducts = products.OrderBy(p => p.UnitPrice);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}\nProduct Price: {product.UnitPrice}");
            }

            //4.Get all products where UnitPrice is between 10 and 30

            var rangeProducts = products.Where(p => p.UnitPrice > 10 && p.UnitPrice > 30);

            //5.Get all products that are in stock(UnitsInStock > 0) and
            //belong to the "Condiments" category.

            var instockProducts = products.Where(p => p.UnitsInStock > 0 && p.Category == "Condiments");

            //6.Create a new anonymous type with three properties:
            //● Name → the product name
            //● Price → the unit price
            //● StockStatus → a string: "Available" if UnitsInStock > 0,
            //otherwise "Out of Stock"
            //● Print the result.

            var anonymousProduct = products.Select(p => new
            {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
            });

            foreach (var product in anonymousProduct)
            {
                Console.WriteLine($"Name: {product.Name}\nPrice: {product.Price}\nStockStatus: {product.StockStatus}");
            }

            //7.Print each product's name along with its position (1-based)
            //in the list. Expected format: 1.Chai, 2.Chang, etc.

            var result = products.Select((p, i) => new
            {
                Position = i + 1,
                Name = p.ProductName
            });
            foreach (var product in result)
            {
                Console.WriteLine($"Name: {product.Name}\nPosition: {product.Position}");
            }

            //8.Sort ProductList by Category ascending, then within each
            //category, sort by UnitPrice descending.

            var sortedByCategory = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}\nProduct Price: {product.UnitPrice}");
            }

            //9.Get all products from the "Beverages" category, sorted by
            //UnitsInStock descending. Print name and stock.

            var selectGategory = products.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);
            foreach (var product in sortedProducts)
            {
                Console.WriteLine($"Product Name: {product.ProductName}\nProduct Price: {product.UnitsInStock}");
            }

            //10.Using QUERY SYNTAX with a compound from clause, list
            //all orders placed in 1997 or later showing CustomerID and
            //OrderDate.

            List<Customer> CustomerList = new List<Customer>();

            var newList = from customer in CustomerList
                          from order in customer.Orders
                          where order.OrderDate.Year >= 1997
                          select new
                          {
                              customer.CustomerID,
                              order.OrderDate
                          };

            foreach (var customer in newList)
            {
                Console.WriteLine($"CustomerID: {customer.CustomerID}\nOrder Date: {customer.OrderDate}");
            }

            //11.Show position number alongside ProductName

            var showposition = products.Select((p, i) => new
            {
                Name = p.ProductName,
                PositionNumber = i + 1,
            });
            foreach (var product in showposition)
            {
                Console.WriteLine($"Name: {product.Name}, Position: {product.PositionNumber} ");

            }



            //12.Sort first by-word length and then by a
            //case -insensitive sort of the words in an array.
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedBylength = Arr.OrderBy(p => p.Length).ThenBy(p => p, StringComparer.OrdinalIgnoreCase);

            //13.Create a list of all digits in the array whose second
            //letter is 'i' that is reversed from the order in the
            //original array.

            var secondLetter = Arr.Where(p => p.Length > 1 && p[1] == 'i').Reverse().ToList();

            foreach (var word in sortedBylength)
            {
                Console.WriteLine(word);
            }


        }
    }
}
