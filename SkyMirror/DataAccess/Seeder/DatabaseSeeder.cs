using SkyMirror.DatabaseContext;
using SkyMirror.Entities;

namespace SkyMirror.DataAccess.Seeder
{
    public static class DatabaseSeeder
    {
        public static void SeedRoles(SkyMirrorDbContext context)
        {
            if(!context.UserRoles.Any())
            {
                context.UserRoles.AddRange
                    (
                        new UserRole { RoleName = "Manager"},
                        new UserRole { RoleName = "Customer"}   
                    );
                context.SaveChanges();
            }

            if(!context.ProductCategories.Any())
            {
                context.ProductCategories.AddRange
                    (
                        new ProductCategory { Name = "Monofacial"},
                        new ProductCategory { Name = "Bifacial"},
                        new ProductCategory { Name = "Topcon"}
                    );
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                var monofacialCategory = context.ProductCategories.FirstOrDefault(c => c.Name == "Monofacial");
                var bifacialCategory = context.ProductCategories.FirstOrDefault(c => c.Name == "Bifacial");
                var topconCategory = context.ProductCategories.FirstOrDefault(c => c.Name == "Topcon");

                if (monofacialCategory != null && bifacialCategory != null && topconCategory != null)
                {

                    context.Products.AddRange
                    (
                        new Product { 
                            CategoryId = monofacialCategory.CategoryId, 
                            Description = "This is a Monofacial Solar Panel",
                            PanelName = "MONOCRYSTALLINE SILICON | PHOTOVOLTAIC MODULES",
                            PowerInWatts = 275,
                            Price = 40000,
                            StockQuantity = 100
                        },
                        new Product { 
                            CategoryId = monofacialCategory.CategoryId, 
                            Description = "This is a Monofacial Solar Panel",
                            PanelName = "MONOCRYSTALLINE SILICON | PHOTOVOLTAIC MODULES",
                            PowerInWatts = 560,
                            Price = 55000,
                            StockQuantity = 100
                        },
                        new Product { 
                            CategoryId = bifacialCategory.CategoryId, 
                            Description = "This is a Bifacial Solar Panel",
                            PanelName = "MONOCRYSTALLINE SILICON | BIFACIAL PV MODULES",
                            PowerInWatts = 290,
                            Price = 45000,
                            StockQuantity = 100
                        },
                        new Product { 
                            CategoryId = bifacialCategory.CategoryId, 
                            Description = "This is a Bifacial Solar Panel",
                            PanelName = "MONOCRYSTALLINE SILICON | BIFACIAL PV MODULES",
                            PowerInWatts = 510,
                            Price = 60000,
                            StockQuantity = 100
                        },
                        new Product { 
                            CategoryId = topconCategory.CategoryId, 
                            Description = "This is a Topcon Solar Panel",
                            PanelName = "TOPCON MODULES",
                            PowerInWatts = 600,
                            Price = 65000,
                            StockQuantity = 100
                        },
                        new Product { 
                            CategoryId = topconCategory.CategoryId, 
                            Description = "This is a Topcon Solar Panel",
                            PanelName = "TOPCON MODULES",
                            PowerInWatts = 650, 
                            Price = 70000,
                            StockQuantity = 100
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
