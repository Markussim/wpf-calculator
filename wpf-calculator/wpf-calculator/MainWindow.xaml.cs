using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private TextBlock MyTextBlock;

        public MainWindow()
        {
            InitializeComponent();

            for (int i = 0; i < 5; i++)
            {
                main.RowDefinitions.Add(new RowDefinition());
            }
            
            for (int i = 0; i < 4; i++)
            {
                main.ColumnDefinitions.Add(new ColumnDefinition());
            }

            MyTextBlock = new TextBlock
            {
                FontSize = 50,
                TextAlignment = TextAlignment.Right,
                HorizontalAlignment = HorizontalAlignment.Right,
                Background = Brushes.Red

            };

            main.Children.Add(MyTextBlock);

            MyTextBlock.SetValue(Grid.RowProperty, 0);
            MyTextBlock.SetValue(Grid.ColumnProperty, 0);
            MyTextBlock.SetValue(Grid.ColumnSpanProperty, 3);


            char[,] layout = new char[,] { 
                {  ' ', ' ', ' ', '+' },
                {  '7', '8', '9','-' },
                {  '4', '5', '6','*' }, 
                {  '1', '2', '3', '/' },
                { ' ', '0', 'C', '=' }
            };

            for(int i = 0; i < layout.GetLength(0); i++)
            {
                for (int j = 0; j < layout.GetLength(1); j++)
                {
                    if (layout[i, j].Equals(' ')) continue;
                    Button dynamicButton = new Button();
                    dynamicButton.SetValue(Grid.ColumnProperty, j);
                    dynamicButton.SetValue(Grid.RowProperty, i);
                    dynamicButton.SetValue(ContentProperty, layout[i, j]);
                    dynamicButton.Click += new RoutedEventHandler(clickButton);
                    main.Children.Add(dynamicButton);
                }
            }

        }

        private void clickButton(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is Button btn)) return;

            if (btn.Content.Equals('='))
            {
                try
                {
                    calc(MyTextBlock.Text);
                } catch
                {
                    MyTextBlock.Text = "Error";
                }
                
            } else if(btn.Content.Equals('C')) {
                MyTextBlock.Text = "";
            } else if(!MyTextBlock.Text.Equals("Error"))
            {
                MyTextBlock.Text += btn.Content;
            }

            
        }

        private void calc(String input)
        {
            var firstNum = int.Parse(Regex.Match(input, @"\d+").Value);
            //var operatorString = input.Substring(firstNum.Length, firstNum.Length);
            var operatorString = input[firstNum.ToString().Length].ToString();
            var secondNum = int.Parse(input.Remove(0, firstNum.ToString().Length + operatorString.Length));

            var output = "";

            switch (operatorString)
            {
                case "+":
                    output = (firstNum + secondNum).ToString();
                    break;
                case "*":
                    output = (firstNum * secondNum).ToString();
                    break;
                case "/":
                    output = (firstNum / secondNum).ToString();
                    break;
                case "-":
                    output = (firstNum - secondNum).ToString();
                    break;
            }

            MyTextBlock.Text = output;


        }
    }
}
