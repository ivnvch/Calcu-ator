using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double firstOperand;
        double secondOperand;
        Double result = 0;

        char token;
        public MainWindow()
        {
            InitializeComponent();
            TbScreen.MaxLength = 10;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
           
            if (TbScreen.Text.Length == 9 && TbScreen.Text[0] != '-')
            {
                TbScreen.Text += "";
            }
            else if (TbScreen.Text.Length == 10 && TbScreen.Text.Contains("-")) 
            {
                TbScreen.Text += "";
            }
            else
            {
                TbScreen.Text += button.Content.ToString();
            }
            try
            {
                secondOperand = Double.Parse(TbScreen.Text);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Divite_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                firstOperand = Double.Parse(TbScreen.Text);
                token = '÷';
                ShowData.Content = $"{firstOperand} {token}";
                TbScreen.Clear();
            }
            catch (Exception)
            {

            }
           
        }

        private void Multiple_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                firstOperand = Double.Parse(TbScreen.Text);
                token = '*';
                ShowData.Content = $"{firstOperand} {token}";
                TbScreen.Clear();
            }
            catch (Exception)
            { 
            }
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (firstOperand == 0 && !TbScreen.Text.Contains("-"))
            {
                //string emm = TbScreen.Text;
                //emm.Substring(0);
                //first = Double.Parse(TbScreen.Text);
                //TbScreen.Text.Insert(0,"-");
                TbScreen.Text += "-";
            }
            try
            {
                firstOperand = double.Parse(TbScreen.Text);
                token = '-';

                ShowData.Content = $"{firstOperand} {token}";
                TbScreen.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                firstOperand = Double.Parse(TbScreen.Text);
                token = '+';
                ShowData.Content = $"{firstOperand} {token}";
                TbScreen.Clear();
            }
            catch (Exception)
            {

            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                secondOperand = Double.Parse(TbScreen.Text);

                if (token == '+')
                {
                    result = firstOperand + secondOperand;
                }
                else if (token == '-')
                {
                    result = firstOperand - secondOperand;
                }
                else if (token == '*')
                {
                    result = firstOperand * secondOperand;
                }
                else if (token == '÷')
                {
                    try
                    {
                        result = firstOperand / secondOperand;
                    }
                    catch (DivideByZeroException ex)
                    {
                        MessageBox.Show(ex + "На нуль делить нельзя!");
                    }
                }

                TbScreen.Text = result.ToString();
                ShowData.Content = $"{firstOperand} {token} {secondOperand} = ";//результат должен увеличиваться на второй операнд
            }
            catch (Exception)
            {

            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TbScreen.Clear();
            ShowData.Content = "";
            firstOperand = 0;
            secondOperand = 0;
        }

        private void Exchange_Click(object sender, RoutedEventArgs e)
        {
            TbScreen.Text = (result * (-1)).ToString();
        }

        private void TbScreen_TextInput(object sender, TextCompositionEventArgs e)
        {
            //TbScreen.Text += e.Text;
            //if (TbScreen.Text.Length == 9 && TbScreen.Text[0] != '-')
            //{
            //    TbScreen.Text += "";
            //}
            //else if (TbScreen.Text.Length == 10 && TbScreen.Text.Contains("-"))
            //{
            //    TbScreen.Text += "";
            //}
            //else
            //{
            //    TbScreen.Text += e.Text;
            //}
            //try
            //{
            //    second = Double.Parse(TbScreen.Text);
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //}
        }

        private void TbScreen_KeyDown(object sender, KeyEventArgs e)
        {
            TbScreen.Text += e.Key.ToString();
        }
    }
}
