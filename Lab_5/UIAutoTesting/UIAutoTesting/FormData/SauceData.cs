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

        public class SauceName
        {
            public Sauce Sauce { get; set; }

            public string SaucePublicName =>
                Sauce switch
                {
                    Sauce.Mayonnaise => "Майонезный",
                    Sauce.Ketchup => "Томатный",
                    Sauce.Cheese => "Сырный",
                    Sauce.Garlic => "Чесночный",
                    _ => throw new ArgumentOutOfRangeException(nameof(Sauce), Sauce, null)
                };

            public SauceName(Sauce sauce)
            {
                Sauce = sauce;
            }

            public override string ToString()
            {
                return SaucePublicName;
            }
        }
    }
}