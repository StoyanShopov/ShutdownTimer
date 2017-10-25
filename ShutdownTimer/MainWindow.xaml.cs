using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "0";
            textBox2Collapsed.Text += "0";
        }
        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "1";
            textBox2Collapsed.Text += "1";
        }
        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "2";
            textBox2Collapsed.Text += "2";
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "3";
            textBox2Collapsed.Text += "3";
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "4"; 
            textBox2Collapsed.Text += "4";
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "5";
            textBox2Collapsed.Text += "5";
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "6";
            textBox2Collapsed.Text += "6";
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "7";
            textBox2Collapsed.Text += "7";
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "8";
            textBox2Collapsed.Text += "8";
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text += "9";
            textBox2Collapsed.Text += "9";
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            textBox1.Clear();
            textBox2Collapsed.Clear();
        }

        private async void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            int totalMinutes;
            bool isBigger = int.TryParse(textBox1.Text, out totalMinutes);
            await Task.Delay(1800);
            if (isBigger)
            {
                int hours = totalMinutes / 60;
                int mins = totalMinutes % 60;
                textBox1.Text = hours.ToString("D2") + "h " + mins.ToString("D2") + "m";
            } 
        }

        private void Button_Shutdown(object sender, RoutedEventArgs e)
        {
            int seconds = int.Parse(textBox2Collapsed.Text) * 60;
            string shutDownCommand = $"shutdown /s /t {seconds}";
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + shutDownCommand);
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }

        private void Button_Abort(object sender, RoutedEventArgs e)
        {

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + "shutdown -a");
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
        }
    }
}