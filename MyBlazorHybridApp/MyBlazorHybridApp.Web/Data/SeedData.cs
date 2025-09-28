﻿using BlazingPizza;
using MyBlazorHybridApp.Shared.Models;

namespace MyBlazorHybridApp.Web.Data;

public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {
        if (db.Specials.Any()) return; // sudah ada data

        db.Specials.AddRange(
            new PizzaSpecial { Name = "Basic Cheese Pizza", Description = "It's cheesy and delicious. Why wouldn't you want one?", BasePrice = 9.99m, ImageUrl = "/img/pizzas/cheese.jpg" },
            new PizzaSpecial { Name = "The Baconatorizor", Description = "It has EVERY kind of bacon", BasePrice = 11.99m, ImageUrl = "/img/pizzas/bacon.jpg" },
            new PizzaSpecial { Name = "Classic pepperoni", Description = "It's the pizza you grew up with, but Blazing hot!", BasePrice = 10.50m, ImageUrl = "/img/pizzas/pepperoni.jpg" },
            new PizzaSpecial { Name = "Buffalo chicken", Description = "Spicy chicken, hot sauce and bleu cheese, guaranteed to warm you up", BasePrice = 12.75m, ImageUrl = "/img/pizzas/meaty.jpg" },
            new PizzaSpecial { Name = "Mushroom Lovers", Description = "It has mushrooms. Isn't that obvious?", BasePrice = 11.00m, ImageUrl = "/img/pizzas/mushroom.jpg" },
            new PizzaSpecial { Name = "Veggie Delight", Description = "It's like salad, but on a pizza", BasePrice = 11.50m, ImageUrl = "/img/pizzas/salad.jpg" },
            new PizzaSpecial { Name = "Margherita", Description = "Traditional Italian pizza with tomatoes and basil", BasePrice = 9.99m, ImageUrl = "/img/pizzas/margherita.jpg" }
        );

        db.SaveChanges();
    }
}
