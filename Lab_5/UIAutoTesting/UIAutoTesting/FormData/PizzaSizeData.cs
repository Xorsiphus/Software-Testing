using System;
using System.Collections.Generic;
using System.Linq;

namespace UIAutoTesting.FormData
{
    public static class PizzaSizeData
    {
        public static List<PizzaSize> GetSizes => Enum.GetNames(typeof(Size))
            .Select(name => new PizzaSize((Size) Enum.Parse(typeof(Size), name))).ToList();

        public enum Size
        {
            Small,
            Medium,
            Large
        }
        
        public static string SizePublicName(Size size) =>
            size switch
            {
                Size.Small => "маленькая",
                Size.Medium => "средняя",
                Size.Large => "большая",
                _ => throw new ArgumentOutOfRangeException(nameof(Size), size, null)
            };
        
        public class PizzaSize
        {
            public Size Size { get; set; }

            public PizzaSize(Size size)
            {
                Size = size;
            }

            public override string ToString()
            {
                return SizePublicName(Size);
            }
        }
    }
}