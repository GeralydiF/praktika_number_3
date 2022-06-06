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

namespace praktika_number_3
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

        private void contains_Click(object sender, RoutedEventArgs e)
        {
            contains_result.Text = contains_first_string.Text.Contains(contains_second_string.Text).ToString();
        }

        private void concat_Click(object sender, RoutedEventArgs e)
        {
            concat_result.Text = string.Concat(concat_first_string.Text, concat_second_string.Text);
        }

        private void endswith_Click(object sender, RoutedEventArgs e)
        {
            endswith_result.Text = endswith_first_string.Text.Contains(endswith_second_string.Text).ToString();
        }

        private void index_Click(object sender, RoutedEventArgs e)
        {
            if (!index_first_string.Text.Contains(index_second_string.Text))
            {
                index_result.Text = "Подстрока не входит строку";
            }
            else
            {
                index_result.Text = $"Индекс первого вхождения: {index_first_string.Text.IndexOf(index_second_string.Text).ToString()}" +
                                $" \nИндекс последнего вхождения: {index_first_string.Text.LastIndexOf(index_second_string.Text).ToString()}";
            }
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
  
                try
                {
                    insert_result.Text = insert_first_string.Text.Insert(Convert.ToInt32(insert_index.Text), insert_second_string.Text);
                }
                catch (Exception exep)
                {
                    MessageBox.Show(exep.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
 
        }

        private void join_Click(object sender, RoutedEventArgs e)
        {
            join_result.Text = string.Join(join_second_string.Text, join_first_string.Text.Split());
        }

        private void replace_Click(object sender, RoutedEventArgs e)
        {
            replace_result.Text = replace_string.Text.Replace(replace_old_string.Text, replace_new_string.Text);
        }

        private void split_Click(object sender, RoutedEventArgs e)
        {
            split_result.Text = "";
            string[] split_res = split_first_string.Text.Split(split_second_string.Text);
            foreach (string elem in split_res)
            {
                split_result.Text += elem + "\n";
            }
        }

        private void substring_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (substring_length.Text == "")
                {
                    Exception ex = ExceptionFunctions.Ex_Int(substring_start.Text, "\"Начальный индекс\"", 0);
                    if (ex == null)
                    {
                        substring_result.Text = substring_string.Text.Substring(Convert.ToInt32(substring_start.Text));
                    }
                    else
                    {
                        throw ex;
                    }
                }
                else
                {
                    Exception[] ex = new Exception[2];
                    ex[0] = ExceptionFunctions.Ex_Int(substring_start.Text, "\"Начальный индекс\"", 0);
                    ex[1] = ExceptionFunctions.Ex_Int(substring_length.Text, "\"Длина подстроки\"", 0);
                    if (ex[0] == null && ex[1] == null)
                    {
                        substring_result.Text = substring_string.Text.Substring(Convert.ToInt32(substring_start.Text), Convert.ToInt32(substring_length.Text));
                    }
                    else
                    {
                        string error = "";
                        foreach (Exception exep in ex)
                        {
                            if (exep != null)
                            {
                                error += exep.Message + "\n";
                            }
                        }
                        throw new Exception(error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void toul_Click(object sender, RoutedEventArgs e)
        {
            toul_result.Text = $"ToUpper: {toul_string.Text.ToUpper()} \nToLower: {toul_string.Text.ToLower()}";
        }

        private void trim_Click(object sender, RoutedEventArgs e)
        {
            if (trim_char.Text == "")
            {
                trim_result.Text = trim_string.Text.Trim();
            }
            else
            {
                char[] chr = trim_char.Text.ToCharArray();
                trim_result.Text = trim_string.Text.Trim(chr);
            }
        }
    }
}
