namespace UIAutoTesting.OrderEntity
{
    public class Order
    {
        public string Address { get; set; }
        public string Time { get; set; }
        public string PizzaName { get; set; }
        public string PizzaSize { get; set; }
        public string Drink { get; set; }
        public string Sauce { get; set; }

        public Order(string address, string time, string pizzaName, string pizzaSize, string drink, string sauce)
        {
            Address = address;
            Time = time;
            PizzaName = pizzaName;
            PizzaSize = pizzaSize;
            Drink = drink;
            Sauce = sauce;
        }

        public override string ToString()
        {
            return $"Ваш заказ на {Address}({Time}): Пицца {PizzaSize} {PizzaName}; Напиток: {Drink}; Соус: {Sauce}";
        }
    }
}