using UIAutoTesting.FormData;
using UIAutoTesting.OrderEntity.OrderService;

namespace UIAutoTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            EnvironmentHelper.SetMode();

            InitializeComponent();

            PizzaNameComboBox.ItemsSource = PizzaNameData.GetNames;
            PizzaSizeComboBox.ItemsSource = PizzaSizeData.GetSizes;
            DrinksComboBox.ItemsSource = DrinksData.GetDrinks;
            SaucesComboBox.ItemsSource = SauceData.GetSauces;

            IOrderService service = EnvironmentHelper.GetOrderService;
            OrderSubmitButton.Click += service.UpdateOrder;
        }
    }
}