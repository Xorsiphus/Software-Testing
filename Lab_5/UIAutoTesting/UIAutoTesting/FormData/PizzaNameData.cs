using System;
using System.Collections.Generic;
using System.Linq;

namespace UIAutoTesting.FormData
{
    public static class PizzaNameData
    {
        public static List<PizzaName> GetNames => Enum.GetNames(typeof(Name))
            .Select(name => new PizzaName((Name) Enum.Parse(typeof(Name), name))).ToList();

        public enum Name
        {
            Neapolitan,
            Siberian,
            Spicy,
            Mexican,
            Florida,
            Bavarian,
        }

        public class PizzaName
        {
            public Name Name { get; set; }

            public string PizzaPublicName =>
                Name switch
                {
                    Name.Neapolitan => "Неаполитана",
                    Name.Siberian => "Сибирская",
                    Name.Spicy => "Пикантная",
                    Name.Mexican => "Мексиканская",
                    Name.Florida => "Флорида",
                    Name.Bavarian => "Баварская",
                    _ => throw new ArgumentOutOfRangeException(nameof(Name), Name, null)
                };

            public PizzaName(Name name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return PizzaPublicName;
            }
        }
    }
}