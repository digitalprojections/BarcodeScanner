using System.Windows;
using System.Diagnostics;
using BarcodeScanner.DATABASE;
using System.Windows.Data;
using Microsoft.EntityFrameworkCore;
using BarcodeScanner.Views;

namespace BarcodeScanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DBContext dbContext = new DBContext();
        private CollectionViewSource categoryViewSource;
        public MainWindow()
        {            
            InitializeComponent();

            categoryViewSource = (CollectionViewSource)this.FindResource(nameof(categoryViewSource));
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dbContext.Database.EnsureCreated();

            dbContext.Categories.Load();
            categoryViewSource.Source = dbContext.Categories.Local.ToObservableCollection();

            if (dbContext.Products.Local.ToObservableCollection().Count==0)
            {
                int ptracker = 0;
                            for (int j = 1; j <= 40; j++)
                            {
                                for (int i = 1; i <= 40; i++)
                                {
                                    ptracker++;
                                    dbContext.Products.Add(new Product { ProductID = ptracker, Name = "Product " + ptracker, CategoryID = j });
                                }
                            }
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            dbContext.SaveChanges();
            //dBContext.Dispose();
            //base.OnClosing(e);
            prodsgrid.Items.Refresh();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            dbContext.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CustomerWindow();
            dlg.Show();
        }
    }
}
