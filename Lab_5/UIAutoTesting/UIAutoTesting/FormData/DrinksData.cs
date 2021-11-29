using System;
using System.Collections.Generic;
using System.Linq;

namespace UIAutoTesting.FormData
{
    public class DrinksData
    {
        public static List<DrinkName> GetDrinks => Enum.GetNames(typeof(Drink))
            .Select(name => new DrinkName((Drink) Enum.Parse(typeof(Drink), name))).ToList();

        public enum Drink
        {
            Tea,
            Soda,
            Juice,
            Water,
        }
        
        public static string DrinkPublicName(Drink drink) =>
            drink switch
            {
                Drink.Tea => "Чай",
                Drink.Soda => "Газировка",
                Drink.Juice => "Сок",
                Drink.Water => "Вода",
                _ => throw new ArgumentOutOfRangeException(nameof(Drink), drink, null)
            };

        public class DrinkName
        {
            public Drink Drink { get; set; }
            
            public DrinkName(Drink drink)
            {
                Drink = drink;
            }

            public override string ToString()
            {
                return DrinkPublicName(Drink);
            }
        }
    }
}