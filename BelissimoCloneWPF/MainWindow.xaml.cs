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
        private void yetkazib_berish_btn_Click(object sender, RoutedEventArgs e)
        {
            yetkazib_berish_btn.IsEnabled = false;
            olib_ketish_btn.IsEnabled = true;

            manzil_btn.Visibility = Visibility.Visible;
            filial_btn.Visibility = Visibility.Collapsed;
        }

        private void olib_ketish_btn_Click(object sender, RoutedEventArgs e)
        {
            olib_ketish_btn.IsEnabled = false;
            yetkazib_berish_btn.IsEnabled = true;

            manzil_btn.Visibility = Visibility.Collapsed;
            filial_btn.Visibility = Visibility.Visible;
        }
    }
}
