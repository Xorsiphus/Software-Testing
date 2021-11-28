using System;
using UIAutoTesting.OrderEntity.OrderService;

namespace UIAutoTesting
{
    public static class EnvironmentHelper
    {
        private static bool _isTesting;
        public static IOrderService GetOrderService => _isTesting ? new OrderServiceStub() : new OrderService();

        public static void SetMode()
        {
            foreach (var arg in Environment.GetCommandLineArgs())
            {
                if (arg.Equals("Testing"))
                {
                    _isTesting = true;
                }
            }
        }
    }
}