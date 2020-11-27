using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace wpf_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                main.RowDefinitions.Add(new RowDefinition());
                main.ColumnDefinitions.Add(new ColumnDefinition());
            }

            char[,] layout = new char[,] { 
                { '7', '8', '9' },
                { '4', '5', '6' },
                { '1', '2', '3' }, 
                { 'a', '0', 'b' }
            };

            for(int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    Button dynamicButton = new Button();
                    dynamicButton.SetValue(ContentProperty, "hmm");
                    dynamicButton
                    MyTextBlock.Text += layout[i, j].ToString();
                }
                MyTextBlock.Text += '\n';
            }

        }
    }
}
