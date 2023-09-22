using GeekShooping.ProductApi.Model.Base;

namespace GeekShooping.ProductApi.Infra.Data
{
    public class SeedingService
    {
        private ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Products.Any() ||
               _context.Categories.Any())
            {
                return; //DB has been seeded
            }

            Category c0 = new Category { Name = "Mug" };
            Category c1 = new Category { Name = "T-Shirt" };
            Category c2 = new Category { Name = "Action Figure" };
            Category c3 = new Category { Name = "Sweatshirt" };
            Category c4 = new Category { Name = "Book" };

            Product p0 = new Product
            {
                Name = "Caneca",
                Price = 39.50,
                Description = "Uma caneca",
                CategoryId = 1,
                Category = c0,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true"
            };

            Product p1 = new Product
            {
                Name = "Camiseta",
                Price = 75.50,
                Description = "Uma camiseta",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true"
            };

            Product p2 = new Product
            {
                Name = "Capacete Darth Vader Star Wars Black Series",
                Price = 999.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 3,
                Category = c2,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg?raw=true",
            };

            Product p3 = new Product
            {
                Name = "Star Wars The Black Series Hasbro - Stormtrooper Imperial",
                Price = 189.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 3,
                Category = c2,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg?raw=true",
            };

            Product p4 = new Product
            {                
                Name = "Camiseta Gamer",
                Price = 69.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true",
            };

            Product p5 = new Product
            {
                Name = "Camiseta Gamer com RGB",
                Price = 69.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg?raw=true",
            };

            Product p6 = new Product
            {
                Name = "Camiseta SpaceX",
                Price = 49.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg?raw=true",
            };

            Product p7 = new Product
            {
                Name = "Camiseta Feminina Coffee Benefits",
                Price = 69.9,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg?raw=true",
            };

            Product p8 = new Product
            {
                Name = "Moletom Com Capuz Cobra Kai",
                Price = 159.9,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 4,
                Category = c3,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg?raw=true",
            };

            Product p9 = new Product
            {
                Name = "Livro Star Talk – Neil DeGrasse Tyson",
                Price = 49.9,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 5,
                Category = c4,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg?raw=true",
            };

            Product p10 = new Product
            {
                Name = "Star Wars Mission Fleet Han Solo Nave Milennium Falcon",
                Price = 359.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 3,
                Category = c2,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg?raw=true",
            };

            Product p11 = new Product
            {
                Name = "Camiseta Elon Musk Spacex Marte Occupy Mars",
                Price = 59.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/11_mars.jpg?raw=true",
            };

            Product p12 = new Product
            {
                Name = "Camiseta GNU Linux Programador Masculina",
                Price = 59.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/12_gnu_linux.jpg?raw=true",
            };

            Product p13 = new Product
            {
                Name = "Camiseta Goku Fases",
                Price = 59.99,
                Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout.<br/>The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English.<br/>Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy.",
                CategoryId = 2,
                Category = c1,
                ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/13_dragon_ball.jpg",
            };

            _context.Categories.AddRange(c1, c2, c3, c4);
            _context.Products.AddRange(p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13);
            _context.SaveChanges();
        }
    }
}
