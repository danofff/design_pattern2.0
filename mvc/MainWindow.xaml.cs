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

namespace mvc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int calculationValue;

        Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller(this, new Model());
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            controller.Execute();
        }

        public int getFirst()
        {
            return Int32.Parse(First.Text);
        }

        public int getSecond()
        {
            return Int32.Parse(Second.Text);
        }

        public int getSolution()
        {
            return Int32.Parse(Result.Text);
        }

        public void SetSolution(int res)
        {
            Result.Text = res.ToString();
        }
    }
}
