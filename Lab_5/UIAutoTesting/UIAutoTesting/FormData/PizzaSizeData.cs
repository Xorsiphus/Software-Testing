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
        
        public class PizzaSize
        {
            public Size Size { get; set; }

            public string SizeName =>
                Size switch
                {
                    Size.Small => "маленькая",
                    Size.Medium => "средняя",
                    Size.Large => "большая",
                    _ => throw new ArgumentOutOfRangeException(nameof(Size), Size, null)
                };

            public PizzaSize(Size size)
            {
                Size = size;
            }

            public override string ToString()
            {
                return SizeName;
            }
        }
    }
}