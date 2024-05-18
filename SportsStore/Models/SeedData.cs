﻿using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<StoreDBContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Porsche 911",
                    Description = "The Porsche 911 is an iconic sports car renowned for its timeless design, precision engineering, and exceptional driving dynamics. With a rear-engine layout and a powerful flat-six engine, the 911 delivers thrilling performance and a distinctive driving experience.",
                    Category = "Sports Car",
                    Price = 5000.95m
                },
                new Product
                {
                    Name = "Mercedes-Benz S-Class",
                    Description = "The Mercedes-Benz S-Class is a flagship luxury sedan known for its opulent interior, cutting-edge technology, and smooth, powerful performance. It offers a range of high-end features, including advanced driver-assistance systems, luxurious materials, and a quiet, comfortable ride.",
                    Category = "Luxury Sedan",
                    Price = 5000.95m
                },
                new Product
                {
                    Name = "Toyota Land Cruiser",
                    Description = "The Toyota Land Cruiser is a rugged and reliable full-size SUV with a reputation for off-road capability and durability. It combines a powerful V8 engine with a spacious, upscale interior, making it suitable for both off-road adventures and comfortable on-road journeys.",
                    Category = "Full-Size SUV",
                    Price = 8500.00m
                },
                new Product
                {
                    Name = "Tesla Model S",
                    Description = "The Tesla Model S is a high-performance electric sedan that offers impressive range, rapid acceleration, and advanced technology. It features a minimalist interior with a large touchscreen interface and Autopilot capabilities for semi-autonomous driving.",
                    Category = "Electric Sedan",
                    Price = 7000.00m
                },
                new Product
                {
                    Name = "Toyota Camry",
                    Description = "The Toyota Camry is a popular midsize sedan known for its reliability, fuel efficiency, and comfortable ride. It offers a range of engine options, including a fuel-efficient hybrid, and comes with a suite of safety features and modern infotainment options.",
                    Category = "Midsize Sedan",
                    Price = 35000.00m
                },
                new Product
                {
                    Name = "Volkswagen Golf",
                    Description = "The Volkswagen Golf is a versatile compact hatchback that combines practicality with a fun-to-drive character. It offers a well-designed interior, a range of efficient engines, and a reputation for solid build quality and reliability.",
                    Category = "Compact Hatchback",
                    Price = 300.00m
                });
                context.SaveChanges();
            }
        }
    }
}