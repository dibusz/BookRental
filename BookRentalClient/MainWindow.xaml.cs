using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookRentalClient
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

        private const string BookDBPath = "books.csv";

        private void NewBook_Click(object sender, RoutedEventArgs e)
        {
            BookEditorWindow window = new BookEditorWindow();
            
            if (window.ShowDialog() == true) 
            {
                LB_Books.Items.Add(window.Book);
                Save();
            }
        }

        private void DeleteBook_click(object sender, RoutedEventArgs e)
        {
            LB_Books.Items.Remove(LB_Books.SelectedItem);
            Save();
        }

        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            BookEditorWindow window = new BookEditorWindow();
            window.Book = (Book)LB_Books.SelectedItem;
            if (window.ShowDialog() == true)
            {
                int index = LB_Books.SelectedIndex;
                LB_Books.Items.RemoveAt(index);
                LB_Books.Items.Insert(index, window.Book);
                Save();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(File.Exists(BookDBPath))
            {
                string[] lines = File.ReadAllLines(BookDBPath);
                foreach (string line in lines)
                {
                    Book book = Book.FromCSV(line);
                    LB_Books.Items.Add(book);
                }
            } else
            {
                File.Create(BookDBPath);
            }
            
        }

        private void Save()
        {
            List<string> op = new List<string>();
            foreach (Book item in LB_Books.Items)
            {
                op.Add(item.ToCSV());
            }
            File.WriteAllLines(BookDBPath, op);
        }
    }
}