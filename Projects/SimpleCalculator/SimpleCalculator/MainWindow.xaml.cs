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

namespace SimpleCalculator
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

        private void btnNum(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.Equals("0")) { txtResult.Text = ""; }
            Button btn = (Button)sender;
            if (btn.Content.Equals(".") && CalculatorUtil.bDecimal == false)
            {
                CalculatorUtil.bDecimal = true;
            }
            else if(btn.Content.Equals(".") && CalculatorUtil.bDecimal) { return; }
            if (CalculatorUtil.Valued) { txtResult.Text = ""; CalculatorUtil.Valued = false; }
            txtResult.Text += btn.Content.ToString();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            CalculatorUtil.V1 = Double.NaN;
            CalculatorUtil.V2 = Double.NaN;
            txtResult.Text = "0";
            CalculatorUtil.Valued = false;
            CalculatorUtil.bDecimal = false;
            CalculatorUtil.Op = '\0';
        }

        private void btnOp(object sender, RoutedEventArgs e)
        {
            //if (txtResult.Text.Equals("")) { return; }
          
            if (Double.IsNaN(CalculatorUtil.V1) && Double.IsNaN(CalculatorUtil.V2) && !CalculatorUtil.Valued)
            {
                CalculatorUtil.V1 = Double.Parse(txtResult.Text.ToString());
                txtResult.Text = "";

            }
            else if(!Double.IsNaN(CalculatorUtil.V1) && !CalculatorUtil.Valued){
                CalculatorUtil.V2 = Double.Parse(txtResult.Text.ToString());
                CalculatorUtil.Valued = true;

                CalculatorUtil.V1 = CalculatorUtil.Operation(CalculatorUtil.V1, CalculatorUtil.V2, CalculatorUtil.Op);
                txtResult.Text = CalculatorUtil.V1.ToString();

           
            }
            Button op = (Button)sender;
            CalculatorUtil.Op = Char.Parse(op.Content.ToString());
        }

        private void btnEquals(object sender, RoutedEventArgs e)
        {
            if(!Double.IsNaN(CalculatorUtil.V1) && !CalculatorUtil.Op.Equals('\0') && !txtResult.Equals(""))
            {
               CalculatorUtil.Valued = true;
               CalculatorUtil.V2 = Double.Parse(txtResult.Text);
               CalculatorUtil.V1 = CalculatorUtil.Operation(CalculatorUtil.V1, CalculatorUtil.V2, CalculatorUtil.Op);
               txtResult.Text = CalculatorUtil.V1.ToString();
            }
        }
    }
    public class CalculatorUtil
    {
        public CalculatorUtil()
        {

        }
        private static double _v1 = Double.NaN;
        private static double _v2 = Double.NaN;
        private static char _op;
        public static bool bDecimal = false;
        public static bool Valued = false;
        public static double V1 { get { return _v1; } set { _v1 = value; } }
        public static double V2 { get { return _v2; } set { _v2 = value; } }
        public static char Op { get { return _op; } set { _op = value; } }
        public static double Operation(double n1, double n2, char op)
        {
            double result = 0;
            if (!op.Equals('\0'))
            {
                switch (op)
                {
                    case '+':
                        result = (n1 + n2);
                        break;
                    case '-':
                        result = (n1 - n2);
                        break;
                    case '*':
                        result = (n1 * n2);
                        break;
                    case '/':
                        result = (n1 / n2);
                        break;
                    default:
                        Console.WriteLine("no Operation detected");
                        break;
                }

            }
            Console.WriteLine(result);
            return result;
        }
    }
}
