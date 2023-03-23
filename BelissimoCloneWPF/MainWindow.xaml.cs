using BelissimoCloneWPF.Service.Interfaces.Foods;
using System.Windows;

namespace BelissimoCloneWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IFoodService foodService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void CityTxt_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FoodController foodController = new FoodController();
            foodController.FoodName.Text = "Pizza";
            foodController.FoodDescription.Text = "Pizza";
            MyControll.Items.Add(foodController);
        }
    }
}
