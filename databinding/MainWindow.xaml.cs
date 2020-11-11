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

namespace databinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyDatagrid.ItemsSource = LoadCollectionData();
            //MyDatagrid.AutoGenerateColumns = false;

        }

        private List<MyClass> LoadCollectionData()
        {
            List<MyClass> authors = new List<MyClass>();
            authors.Add(new MyClass()
            {

                MyClassId = 1,
                FirstName = "Bikalpa",
                LastName = "Gyawali"

            });

            authors.Add(new MyClass()
            {
                MyClassId = 2,
                FirstName = "Sanjiv",
                LastName = "Gyawali"
            });

            authors.Add(new MyClass()
            {
                MyClassId = 3,
                FirstName = "Younesh",
                LastName = "KC"
            });

            return authors;
        }

        
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // MyDatagrid.CurrentCell = new DataGridCellInfo((sender as Button).DataContext, MyDatagrid.Columns[0]);
            Button ClickedButton = sender as Button;
            Console.WriteLine(ClickedButton.TemplatedParent);
            string tagName = ClickedButton.Tag.ToString();
            Console.WriteLine(tagName);
            foreach (TextBox tb in FindVisualChildren<TextBox>(this))
            {
                Console.WriteLine(tb.Text);
                if(tb.Tag.ToString()==tagName)
                    tb.IsEnabled = true;
            }

        }


        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }


    public class MyClass
    {

        public int MyClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}