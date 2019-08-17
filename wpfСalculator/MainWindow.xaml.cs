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
namespace wpfTry
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void AddToExp(string str)
        {
            if (ListBox.Items.Count != 0)
            {
                ListBox.Items[ListBox.Items.Count - 1] += str;
            }
            else
            {
                ListBox.Items.Add(str);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("1");   
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("2");
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("3");
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("4");
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("5");
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("6");
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("7");
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("8");
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("9");
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("0");
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("+");
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("-");
        }

        private void MultButton_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("*");
        }

        private void DevideButton_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("/");
        }

        private void LeftBrButton_Click(object sender, RoutedEventArgs e)
        {
            AddToExp("(");
        }

        private void RightBrButton_Click(object sender, RoutedEventArgs e)
        {
            AddToExp(")");
        }

        private void CleanButton_Click(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Clear();
        }

        private void BSButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.Items.Count != 0)
            {
                if (ListBox.Items[ListBox.Items.Count - 1].ToString().Length != 0)
                {
                    StringBuilder sb = new StringBuilder(ListBox.Items[ListBox.Items.Count - 1].ToString());
                    sb.Remove(sb.Length - 1, 1);
                    ListBox.Items[ListBox.Items.Count - 1] = sb.ToString();
                }
                
            }
        }

        private void SolveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListBox.Items.Count != 0)
            {
                try
                {
                    CalculatorLib.Expression exp =
                    new CalculatorLib.Expression(
                        ListBox.Items[ListBox.Items.Count - 1].ToString());
                    ListBox.Items[ListBox.Items.Count - 1] += $" =  {exp.SolveDouble().ToString()}";
                    ListBox.Items.Add("");
                }
                catch (Exception ex)
                {
                    ListBox.Items.Add(ex.Message);
                    ListBox.Items.Add("");
                }
            }else
            {
                ListBox.Items.Add("Выражение пусто");
                ListBox.Items.Add("");
            }
        }
    }
}
