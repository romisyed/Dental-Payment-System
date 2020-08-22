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

namespace Dental_Payment_System
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbProviences.Items.Add("Select proviences");
            cmbProviences.Items.Add("Alberta");
            cmbProviences.Items.Add("Ontario");
            cmbProviences.Items.Add("Quebec");
            lblResult.Visibility = Visibility.Hidden;
            rdbAdult.IsChecked = true;
            cmbProviences.SelectedIndex = 0;
        }

        private void btnCalculate_onClick(object sender, RoutedEventArgs e)
        {
            double flossingPrice = 0, fillingPrice = 0, rootCanalPrice = 0;
            string name = txtName.Text;
            string address = txtAddress.Text;
            double hst = 0;
            if (cmbProviences.SelectedIndex == 1)
                hst = 0.07;
            if (cmbProviences.SelectedIndex == 2)
                hst = 0.13;
            if (cmbProviences.SelectedIndex == 3)
                hst = 0.06;

            double discount = 0;
            if (rdbSenior.IsChecked == true)
                discount = 0.10;
            if (rdbKidsAndYouth.IsChecked == true)
                discount = 0.15;

            if (chkFlossing.IsChecked == true)
                flossingPrice = 20;
            if (chkFilling.IsChecked == true)
                fillingPrice = 75;
            if (chkRootCanal.IsChecked == true)
                rootCanalPrice = 150;
            double totalPrice = flossingPrice + fillingPrice + rootCanalPrice;
            totalPrice = totalPrice - totalPrice * discount;
            totalPrice = totalPrice + totalPrice * hst;
            lblResult.Visibility = Visibility.Visible;
            lblResult.Content = "Bill Charges for " + name + " is " + totalPrice.ToString("C");
        }
    }
}