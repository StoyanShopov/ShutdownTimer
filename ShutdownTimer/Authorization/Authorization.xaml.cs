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

namespace ShutdownTimer
{
    /// <summary>
    /// Interaction logic for ExpandedPage.xaml
    /// </summary>
    public partial class ExpandedPage 
    {
        public ExpandedPage()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string inputPass = PassTextBox.Text;

            if (inputPass == "123")
            {
                AdvancedOptions advOp = new AdvancedOptions();
                advOp.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Parolata e 123");
            }

            PassTextBox.Clear();
        }
    }
}
