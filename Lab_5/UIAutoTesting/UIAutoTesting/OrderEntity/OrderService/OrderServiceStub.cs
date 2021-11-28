using System.Net.Sockets;
using System.Windows;

namespace UIAutoTesting.OrderEntity.OrderService
{
    public class OrderServiceStub : IOrderService
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
            SendFree();
            MessageBox.Show(order.ToString(), "Info");
        }

        private static void SendFree()
        {
            UdpClient client = new UdpClient();
            byte[] data = { 1 };
            client.Send(data, data.Length, "127.0.0.1", 54321);
        }
    }
}