using System.Windows;

namespace UIAutoTesting.OrderEntity.OrderService
{
    public interface IOrderService
    {
        Order GetOrder();
        void SendOrder(Order order);

        void UpdateOrder(object sender, RoutedEventArgs args);
    }
}