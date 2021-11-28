using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace UITestingProject
{
    [TestFixture]
    public class Tests
    {
        private readonly string _applicationPath =
            Path.Combine(TestContext.CurrentContext.TestDirectory.Replace("UITestingProject", "UIAutoTesting"),
                "UIAutoTesting.exe");

        private Window _window;
        private Application _application;
        private UdpClient _client;
        private IPEndPoint _ip = null;

        /// <summary>
        /// Метод, инициализирующий приложение в начале каждого теста
        /// </summary>
        [SetUp]
        public void Init()
        {
            _application = Application.Launch(new ProcessStartInfo(_applicationPath, "Testing"));
            _window = _application.GetWindow("PizzaDelivery", InitializeOption.NoCache);

            _client = new UdpClient(54321);
        }

        /// <summary>
        /// Метод, завершающий приложение
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
            _application.Close();
            _client.Close();
        }


        [Test]
        public void Test1()
        {
            var addressTextBox = _window.Get<TextBox>("AddressTextBox");
            addressTextBox.BulkText = "Main street";

            var timeTextBox = _window.Get<TextBox>("TimeTextBox");
            timeTextBox.BulkText = "21:00";

            var pizzaNameComboBox = _window.Get<ComboBox>("PizzaNameComboBox");
            pizzaNameComboBox.Select(3);

            var pizzaSizeComboBox = _window.Get<ComboBox>("PizzaSizeComboBox");
            pizzaSizeComboBox.Select(2);

            var drinksComboBox = _window.Get<ComboBox>("DrinksComboBox");
            drinksComboBox.Select(1);

            var saucesComboBox = _window.Get<ComboBox>("SaucesComboBox");
            saucesComboBox.Select(0);

            var submitButton = _window.Get<Button>("OrderSubmitButton");
            submitButton.Click();

            byte[] data = _client.Receive(ref _ip);
            Assert.AreEqual(new byte[] {1}, data);

            Window childWindow = _window.MessageBox("Info");
            Assert.AreNotEqual(childWindow, null);
            
            var messageBoxLabel = childWindow.Get<Label>();
            Assert.AreEqual(messageBoxLabel.Text,
                "Ваш заказ на Main street(21:00): Пицца большая Мексиканская; Напиток: Газировка; Соус: Майонезный");

            Thread.Sleep(2000);
        }
    }
}