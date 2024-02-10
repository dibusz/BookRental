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
using System.Windows.Shapes;

namespace BookRentalClient
{
    /// <summary>
    /// Interaction logic for BookEditorWindow.xaml
    /// </summary>
    public partial class BookEditorWindow : Window
    {
        public BookEditorWindow()
        {
            InitializeComponent();
        }

        public Book? Book { get; set; }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Book = new Book();
            Book.Title = TB_Title.Text;
            Book.Author = TB_Author.Text;
            Book.Type = TB_Type.Text;
            Book.Release = DP_Release.SelectedDate;
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(Book != null)
            {
                TB_Title.Text = Book.Title;
                TB_Author.Text = Book.Author;
                TB_Type.Text = Book.Type;
                DP_Release.SelectedDate = Book.Release;
            }
        }
    }
}
