using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BelissimoCloneWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
            olib_ketish_btn.IsEnabled=false;
            yetkazib_berish_btn.IsEnabled=true;

            manzil_btn.Visibility = Visibility.Collapsed;
            filial_btn.Visibility = Visibility.Visible;
        }
    }
}
