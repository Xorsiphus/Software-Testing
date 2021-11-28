using System.Windows;

namespace UIAutoTesting.OrderEntity.OrderService
{
    public class OrderService : IOrderService
    {
        public Order GetOrder()
        {
            throw new System.NotImplementedException();
        }

        public void SendOrder(Order order)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateOrder(object sender, RoutedEventArgs args)
        {
            var order = OrderStatic.GetCurrentOrder();
            SendOrder(order);
            MessageBox.Show(order.ToString(), "Info");
        }
    }
}