using System.Windows;
using System.Diagnostics;
using BarcodeScanner.DATABASE;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;

namespace BarcodeScanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DBContext dBContext = new DBContext();
        private CollectionViewSource categoryViewSource;
        public MainWindow()
        {            
            InitializeComponent();

            categoryViewSource = (CollectionViewSource)this.FindResource(nameof(categoryViewSource));
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dBContext.Database.EnsureCreated();

            dBContext.Categories.Load();
            categoryViewSource.Source = dBContext.Categories.Local.ToObservableCollection();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dBContext.SaveChanges();
            //dBContext.Dispose();
            //base.OnClosing(e);
            prodsgrid.Items.Refresh();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            dBContext.SaveChanges();
        }
    }
}
