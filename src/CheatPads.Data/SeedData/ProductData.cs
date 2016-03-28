using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using CheatPads.Data.Models;

namespace CheatPads.Data.SeedData
{
    public static class ProductData
    {
        public static void EnsureSeeded(DataContext db)
        { 
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(new Category[] {
                    new Category()
                    {
                        Name = "Technical",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Sku = "cp-001",
                                Name = "Git Cheatsheet",
                                Description = ""
                            },
                            new Product()
                            {
                                Sku = "cp-002",
                                Name = "Glob Commands",
                                Description = ""
                            }
                        }

                    },
                    new Category() {
                        Name = "Cartoons",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Sku = "cp-004",
                                Name = "Ren & Stimpy",
                                Description = ""
                            },
                            new Product()
                            {
                                Sku = "cp-005",
                                Name = "Thundercats",
                                Description = ""
                            }
                        }
                    },
                    new Category() {
                        Name = "Chemistry",
                        Products = new List<Product>()
                        {
                            new Product()
                            {
                                Sku = "cp-003",
                                Name = "Periodic Table",
                                Description = ""
                            }
                        }
                    }
                });

                db.SaveChanges();
            }
        }
    }
}
