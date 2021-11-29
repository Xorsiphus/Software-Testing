using System;
using System.Collections.Generic;
using System.Linq;

namespace UIAutoTesting.FormData
{
    public class SauceData
    {
        public static List<SauceName> GetSauces => Enum.GetNames(typeof(Sauce))
            .Select(name => new SauceName((Sauce) Enum.Parse(typeof(Sauce), name))).ToList();

        public enum Sauce
        {
            Mayonnaise,
            Ketchup,
            Cheese,
            Garlic,
        }

        public static string SaucePublicName(Sauce sauce) =>
            sauce switch
            {
                Sauce.Mayonnaise => "Майонезный",
                Sauce.Ketchup => "Томатный",
                Sauce.Cheese => "Сырный",
                Sauce.Garlic => "Чесночный",
                _ => throw new ArgumentOutOfRangeException(nameof(Sauce), sauce, null)
            };
        
        public class SauceName
        {
            public Sauce Sauce { get; set; }

            public SauceName(Sauce sauce)
            {
                Sauce = sauce;
            }

            public override string ToString()
            {
                return SaucePublicName(Sauce);
            }
        }
    }
}