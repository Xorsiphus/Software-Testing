namespace UIAutoTesting.OrderEntity
{
    public class OrderStatic
    {
        public static string Address { get; set; }
        public static string Time { get; set; }
        public static string PizzaName { get; set; }
        public static string PizzaSize { get; set; }
        public static string Drink { get; set; }
        public static string Sauce { get; set; }

        public static Order GetCurrentOrder() => new Order(Address, Time, PizzaName, PizzaSize, Drink, Sauce);
    }
}