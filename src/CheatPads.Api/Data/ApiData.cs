using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using CheatPads.Api.Data.Models;

namespace CheatPads.Api.Data
{
    public static class ApiData
    {
        public static void EnsureSeeded(ApiDbContext db)
        { 
            if (!db.Categories.Any())
            {

                db.Categories.AddRange(new Category[] {
                    new Category()
                    {
                        Name = "Popular",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Sku = "pop-001",
                                Title = "Periodic Table",
                                Details = "",
                                Image = "assets/img/popular/periodic-1.png",
                                Price = 14.99M
                            },
                            new Product()
                            {
                                Sku = "pop-002",
                                Title = "8 Bit Mario",
                                Details = "",
                                Image = "assets/img/popular/mario-1.png",
                                Price = 14.99M
                            },
                            new Product()
                            {
                                Sku = "pop-004",
                                Title = "Grumpy Cat",
                                Details = "",
                                Image = "assets/img/popular/grumpycat-1.png",
                                Price = 11.99M
                            },
                        }
                    },
                    new Category() {
                        Name = "Anime",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Sku = "toon-001",
                                Title = "Elsa",
                                Details = "",
                                Image = "assets/img/cartoon/frozen-1.png",
                                Price = 14.99M
                            },
                            new Product()
                            {
                                Sku = "toon-002",
                                Title = "Lego Movie",
                                Details = "",
                                Image = "assets/img/cartoon/lego-1.png",
                                Price = 13.99M
                            },
                            new Product()
                            {
                                Sku = "toon-003",
                                Title = "Rainbow Cat",
                                Details = "",
                                Image = "assets/img/cartoon/nyancat-1.png",
                                Price = 14.99M
                            },
                            new Product()
                            {
                                Sku = "toon-004",
                                Title = "Scooby Doo",
                                Details = "",
                                Image = "assets/img/cartoon/scooby-1.png",
                                Price = 12.99M
                            },
                            new Product()
                            {
                                Sku = "toon-005",
                                Title = "Shop Keepa",
                                Details = "",
                                Image = "assets/img/cartoon/shopkeepa-1.png",
                                Price = 19.99M
                            },
                            new Product()
                            {
                                Sku = "toon-006",
                                Title = "Snoopy",
                                Details = "",
                                Image = "assets/img/cartoon/snoopy-1.png",
                                Price = 14.99M
                            }
                        }
                    }
                });

                db.SaveChanges();
            }
        }
    }
}
